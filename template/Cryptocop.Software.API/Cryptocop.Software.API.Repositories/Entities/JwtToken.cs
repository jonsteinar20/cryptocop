namespace Cryptocop.Software.API.Repositories.Entities
{
    public class JwtToken
    {
        public int Id { get; set; }
        public bool Blacklisted { get; set; }
    }
}