# Use official Node.js image as base
FROM node:16

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

RUN npm install crypto-browserify

# Copy the rest of the application
COPY . .

# Build the Vue.js app
RUN npm run build

# Install Nginx to serve the app
RUN apt-get update && apt-get install -y nginx

# Copy the built app to Nginx's HTML directory
COPY dist/ /usr/share/nginx/html

# Expose port 80 for the web server
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]