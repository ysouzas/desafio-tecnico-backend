# Use the official Node.js LTS image as the base image
FROM node:16 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the package.json and yarn.lock files to the container
COPY package.json yarn.lock ./

# Install the frontend (React) dependencies
RUN yarn install

# Copy the entire frontend (React) application to the container
COPY . ./

# Build the frontend (React) application
RUN yarn build

# Use the official Nginx image as the base image for serving the frontend
FROM nginx:alpine

# Copy the built frontend (React) files to the Nginx public directory
COPY --from=build /app/build /usr/share/nginx/html

# Expose the port specified in the .env file for the frontend
EXPOSE ${FRONTEND_PORT}

# Start the Nginx server to serve the frontend application
CMD ["nginx", "-g", "daemon off;"]
