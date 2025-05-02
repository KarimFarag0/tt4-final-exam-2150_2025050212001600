# Build the frontend application
FROM node:lts-alpine AS builder

# Set the working directory inside the container
WORKDIR /app

# Copy the frontend app (Vue.js) from your local machine to the container
COPY ./frontend .

# Install dependencies and build the app
RUN npm install
RUN npm run build  # This will build the Vue.js app and generate static files in /dist

# Use Nginx to serve the app
FROM nginx:alpine

# Copy the built app from the builder stage to the Nginx HTML folder
COPY --from=builder /app/dist /usr/share/nginx/html

# Optional: Copy a custom Nginx configuration if you need special configurations
COPY default.conf /etc/nginx/conf.d/default.conf

# Expose port 80 for the frontend app
EXPOSE 80

# Start Nginx to serve the app
CMD ["nginx", "-g", "daemon off;"]