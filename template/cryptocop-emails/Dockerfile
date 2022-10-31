FROM node:latest
LABEL maintainer="Jón Steinar Sölvason"

ENV NODE_ENV er

ENV DBHOST eq
ENV DBNAME wq

COPY . /app
WORKDIR /app
RUN npm install

ENTRYPOINT [ "npm", "run", "build" ]