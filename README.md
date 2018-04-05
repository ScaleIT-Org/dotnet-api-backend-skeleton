<img src="https://raw.githubusercontent.com/ScaleIT-Org/media-ressources/master/logo/scaleit-logo.png" width="50%"/>| <img src="https://github.com/ScaleIT-Org/media-ressources/raw/master/logo/docker-dotnet-microsoft-scaleit.png" />| <img src="https://github.com/ScaleIT-Org/media-ressources/raw/master/logo/scaleit-waben-ionic.png" width="50%"/>
--|--|--

# Dotnet Core Backend Skeleton ![License](https://img.shields.io/github/license/ScaleIT-Org/dotnet-api-backend-skeleton.svg?link=https://github.com/ScaleIT-Org/dotnet-api-backend-skeleton/blob/master/LICENSE)

The Dotnet Core Backend Skeleton is a pre-configured base for ScaleIT Apps. It provides a ready to use production ready scaffolding for ScaleIT Ready Domain Apps.

Give it a try:

    docker-compose up
    # navigate to localhost:5050/index.html

Skeleton Functionality:

1) Simple static serving via Kestrel (can be combined with the (Ionic App Skeleton)[https://github.com/ScaleIT-Org/ionic-app-skeleton])
2) Dotnet Core 2.1 backend with C#

## Technology Stack
    dotnet core -> C# -> Kestrel Web Server

## Usage (Standalone)

    dotnet run

## Usage (Docker)

This skeleton uses a multi stage build in order to create a very small production ready image. This results in an image size of about 200MB compared to the 2GB size of the build image.

Docker Compose:

    [docker-compose build] //optional
    docker-compose up
    
## Development

In order to simplify development we recommend working locally (or with a docker bind mount) and using the dotnet hot reload feature:

    dotnet watch run
    
In order to pull from this repo as upstream you should use githubs rebasing feature:

    git checkout branch
    git pull --rebase origin master

Alternatively use cherry picking (or patching):

    git cherry-pick d147423..2622049
    git cherry-pick d147423
    
## Health Check (Optional)

        #Build with healtcheck enabled
        HEALTHCHECK --interval=5m --timeout=3s \
        CMD curl -f http://localhost:5050/ || exit 1

TODO: tutorials 

## Learning Material

https://www.hanselman.com/blog/OptimizingASPNETCoreDockerImageSizes.aspx

https://medium.com/scaleit/dotnet-core-scaleit-apps-with-docker-62f11ed0032
