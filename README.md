<img src="https://raw.githubusercontent.com/ScaleIT-Org/media-ressources/master/logo/scaleit-logo.png" width="20%"/>
<img src="https://github.com/ScaleIT-Org/media-ressources/raw/master/logo/docker-dotnet-microsoft-scaleit.png" width="40%"/>


# Dotnet Core Backend Skeleton ![License](https://img.shields.io/github/license/ScaleIT-Org/dotnet-api-backend-skeleton.svg?link=https://github.com/ScaleIT-Org/dotnet-api-backend-skeleton/blob/master/LICENSE)

The Dotnet Core Backend Skeleton is a pre-configured base for ScaleIT Apps. It provides a ready to use production ready scaffolding for ScaleIT Ready Domain Apps.

Give it a try:

    docker-compose up
    # navigate to localhost:5050/index.html

Skeleton Functionality:

1) Simple static serving via Kestrel (can be combined with the [Ionic App Skeleton](https://github.com/ScaleIT-Org/ionic-app-skeleton))
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
    
## Testing

We also included a way for unit testing your code. This is especially useful for testing your APIs or business logic.

To run all tests in the project:

    dotnet test

To run a single Test:

    dotnet test --filter "FullyQualifiedName=dotnet_api_backend_skeleton.Test.MQTTServiceTest.TestOnlineConnection"

Other useful arguments:
* --no-build
* --logger ( example `dotnet test --logger "trx;LogFileName=/var/folders/4w/5w1xz9n14wqg5jxvfpjbvf0h0000gp/T/test-explorer/0.trx"`)

Useful Visual Studio Code extensions:
* Test Explorer for C# (it will show console output of the test - unlike the standard test runner)

Note: we had to add new directives in the project configuration (.csproj) to get the tests to run inside the same project. Otherwise you get a `error CS0017: Program has more than one entry point defined`, because the tests also have a main method.
We therefore had to disable packaging (see [this great article](https://andrewlock.net/fixing-the-error-program-has-more-than-one-entry-point-defined-for-console-apps-containing-xunit-tests/) for details):

    <PropertyGroup>
        <TargetFramework>netcoreapp2.0</TargetFramework>
    +    <IsPackable>false</IsPackable>
    +   <GenerateProgramFile>false</GenerateProgramFile>
    </PropertyGroup>

## Health Check (Optional)

        #Build with healtcheck enabled
        HEALTHCHECK --interval=5m --timeout=3s \
        CMD curl -f http://localhost:5050/ || exit 1

TODO: tutorials 

## Learning Material

https://www.hanselman.com/blog/OptimizingASPNETCoreDockerImageSizes.aspx

https://medium.com/scaleit/dotnet-core-scaleit-apps-with-docker-62f11ed0032
