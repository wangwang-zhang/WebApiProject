# Get base sdk Image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#copy the csprog file and restore any dependecies
COPY *.csproj ./
RUN dotnet restore

#copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

#Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "StudentWebAPI.dll"]