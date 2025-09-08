FROM ubuntu AS developer-os
LABEL name="Edward Patch" email="1801492@student.uwtsd.ac.uk"
ENV DEBIAN_FRONTEND noninteractive
RUN apt-get update --fix-missing && \
    apt-get install -y \
    software-properties-common && \
    apt-get install -y --no-install-recommends apt-utils && \
    apt-get install -y curl \
    wget
RUN apt-get install -y sudo
RUN echo "export SERVER_IP_ADDRESS=0.0.0.0" >> /etc/profile
RUN apt-get clean

FROM developer-os AS nodeenv
LABEL author="Edward Patch" email="crazygaming055@gmail.com"

# Create and change the working directory
WORKDIR /var/www/node
RUN curl -fssL https://deb.nodesource.com/setup_18.x | sudo -E bash && \
apt-get install -y nodejs
RUN npm install -g npm && \
npm install -g npx --force
RUN apt-get install inotify-tools -y
RUN npm install -g nodemon
RUN apt-get clean

COPY Client/package.json ./
RUN npm install

#### ASP.NET ##############
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS aspenv
WORKDIR /var/www/dotnet

COPY Server/ .
RUN dotnet restore


RUN dotnet publish -c Release -o ./out --no-restore
 
# To update the C++ library, run the compile-library script.
# Comment this out if you do not want a C++ library.
RUN mv C++/bin/cPostLib.so ./out/

#### THE WEB Client ##############

FROM nodeenv AS client
# Expose our webservers port number
EXPOSE 443
# Change to the working directory
WORKDIR /var/www/node
RUN ls
# Execute the application
ENTRYPOINT ["npm", "run", "dev"]

#### THE WEB Server ##############

# Build runtime image
FROM aspenv AS server
EXPOSE 3000
ENV ASPNETCORE_URLS=http://*:3000
WORKDIR /var/www/dotnet
ENTRYPOINT ["dotnet", "out/Server.dll"]