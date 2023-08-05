# Use the official SQL Server Docker image as the base image
FROM mcr.microsoft.com/mssql/server:2019-latest

# Set the environment variables for SQL Server
ENV ACCEPT_EULA=Y

# Create a directory for SQL Server database files
RUN mkdir -p /var/opt/mssql/data

# Expose the SQL Server port (already defined in the docker-compose.yml)

# Set the default SA password for SQL Server
ARG SA_PASSWORD
ENV SA_PASSWORD=${SA_PASSWORD}

# Set the SQL Server port from the environment variable
ARG SQL_SERVER_PORT
ENV SQL_SERVER_PORT=${SQL_SERVER_PORT}

# Create a new database during container build
RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -Q "CREATE DATABASE YourDatabaseName;"
