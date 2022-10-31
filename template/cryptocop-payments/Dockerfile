FROM node:latest
LABEL maintainer="Jón Steinar Sölvason"

ENV NODE_ENV sd

ENV DBHOST ad
ENV DBNAME fa

COPY . /app
WORKDIR /app
RUN npm install

ENTRYPOINT [ "npm", "run", "build" ]