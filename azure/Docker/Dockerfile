FROM  mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/BackEnd/API/
COPY API.csproj .
RUN dotnet restore "API.csproj"
COPY . .
RUN dotnet publish "API.csproj" -c release -o /publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 as final
WORKDIR /src/App
COPY --from=build /publish .

ENTRYPOINT [ "dotnet", "API.dll" ]