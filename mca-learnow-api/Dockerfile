FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY mca-learnow-api/*.csproj ./mca-learnow-api/
COPY Learnow.Common/*.csproj ./Learnow.Common/
COPY Learnow.Contract/*.csproj ./Learnow.Contract/
COPY Learnow.Domain/*.csproj ./Learnow.Domain/
COPY Learnow.Infrastructure/*.csproj ./Learnow.Infrastructure/
COPY Learnow.Services/*.csproj ./Learnow.Services/


# RUN dotnet restore Learnow.Common/Learnow.Common.csproj
# RUN dotnet restore Learnow.Contract/Learnow.Contract.csproj
# RUN dotnet restore Learnow.Domain/Learnow.Domain.csproj
# RUN dotnet restore Learnow.Infrastructure/Learnow.Infrastructure.csproj
# RUN dotnet restore Learnow.Services/Learnow.Services.csproj

RUN dotnet restore


# copy everything else and build app
COPY . ./
# COPY mca-learnow-api ./aspnetapp/
# COPY Learnow.Common ./aspnetapp/
# COPY Learnow.Contract ./aspnetapp/
# COPY Learnow.Domain ./aspnetapp/
# COPY Learnow.Infrastructure ./aspnetapp/
# COPY Learnow.Services ./aspnetapp/


WORKDIR /app
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "mca-learnow-api.dll"]