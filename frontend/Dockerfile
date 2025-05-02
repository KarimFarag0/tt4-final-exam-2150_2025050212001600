# Use an official Node.js image to build the frontend
FROM node:16 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to install dependencies
COPY ./Frontend/package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the frontend project files
COPY ./Frontend ./

# Build the Vue.js app for production
RUN npm run build

# Use a simple web server to serve the static files
FROM nginx:alpine

# Copy the build folder to the nginx server's web directory
COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80 to be accessible outside the container
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]