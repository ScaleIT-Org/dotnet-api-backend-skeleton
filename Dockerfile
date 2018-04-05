FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
# RUN dotnet build -c Release 
RUN dotnet publish -c Release -o out

##################
# Production image 
FROM microsoft/dotnet:2.1-runtime-alpine AS deploy-env
# use aspnet core https://github.com/NileshGule/dotnet-2017/blob/master/DotNet2017/CoreWebAPI/Dockerfile

# Upgrade to newest packages
RUN apk update && apk upgrade
# Install libuv dependency
RUN apk add --no-cache libuv \
 && ln -s /usr/lib/libuv.so.1 /usr/lib/libuv.so
#Timezone
RUN apk add tzdata && cp /usr/share/zoneinfo/UTC /etc/localtime
RUN echo "UTC" > /etc/timezone
RUN date && apk del tzdata

# Default port for this App Skeleton, will be exposed when -P specified
ENV ASPNETCORE_URLS=http://+:5050
# EXPOSE 80
EXPOSE 5050

# Copy from build stage
WORKDIR /app
COPY --from=build-env /app/out ./

# using array notation causes node to be PID1 and will not exit properly. Without the array notation the shell forwards the sigterm correctly. 
ENTRYPOINT ["dotnet", "dotnet-api-backend-skeleton.dll"]
