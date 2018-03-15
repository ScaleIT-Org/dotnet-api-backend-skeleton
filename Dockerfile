FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
#need to specify target runtime see https://github.com/dotnet/coreclr/issues/13542
# -r linux-arm //for arm builds
# -r linux-x64 
# RUN dotnet build -c Release 
RUN dotnet publish -c Release -r linux-x64 -o out

##################
# Production image 
# FROM microsoft/dotnet:2.1-runtime-alpine
FROM microsoft/dotnet:2.1-runtime-alpine

# Upgrade to newest packages
RUN apk update && apk upgrade
# RUN apk add libc6-compat libunwind
#Timezone
RUN apk add tzdata && cp /usr/share/zoneinfo/Europe/Brussels /etc/localtime
RUN echo "Europe/Berlin" > /etc/timezone
RUN date && apk del tzdata

# Default port for this App Skeleton, will be exposed when -P specified
# ENV ASPNETCORE_URLS=http://+:80
#EXPOSE 80
EXPOSE 5050

# Copy from build stage
WORKDIR /app
COPY --from=build-env /app/out ./

# using array notation causes node to be PID1 and will not exit properly. Without the array notation the shell forwards the sigterm correctly. 
ENTRYPOINT ["./dotnet-api-backend-skeleton"]
