# Use an official Node.js image to build the app
FROM node:16 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# Use an official NGINX image to serve the built app
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
