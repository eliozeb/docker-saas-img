# Use the official .NET 8 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
    ARG NODE_VERSION="none"
    RUN if [ "${NODE_VERSION}" != "none" ]; then curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.1/install.sh | bash && \. ~/.nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1; fi
# [Optional] Uncomment this section to install additional OS packages.
    RUN apt-get update && \
    export DEBIAN_FRONTEND=noninteractive && \
    apt-get -qy full-upgrade && \
    apt-get install -qy curl && \
    apt-get -y install --no-install-recommends vim && \
    curl -sSL https://get.docker.com/ | sh

RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools

# configure for https
RUN dotnet dev-certs https