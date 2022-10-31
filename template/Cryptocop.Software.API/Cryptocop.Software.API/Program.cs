using System.Text.Json.Serialization;
using Cryptocop.Software.API.Services.Implementations;
using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Cryptocop.Software.API.Repositories.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Cryptocop.Software.API.Middlewares;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();

builder.Services.AddDbContext<CryptocopDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("CryptocopConnectionString"), options => {
            options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
            // b => b.MigrationsAssembly("Cryptocop.Software.API"));
    }
        // ServiceLifetime.Singleton
    );

builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtTokenAuthentication(builder.Configuration);

var JwtToken = builder.Configuration.GetSection("JwtToken");
builder.Services.AddTransient<ITokenService>((c) =>
    new TokenService(
        JwtToken.GetValue<string>("secret"),
        JwtToken.GetValue<string>("expirationInMinutes"),
        JwtToken.GetValue<string>("issuer"),
        JwtToken.GetValue<string>("audience")));

builder.Services.AddScoped<IQueueService, QueueService>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddHttpClient<ICryptoCurrencyService, CryptoCurrencyService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CryptocopApiBaseUrl"));
});


// Register services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IExchangeService, ExchangeService>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IQueueService, QueueService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();

// Register repositories
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddTransient<ITokenRepository, TokenRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();