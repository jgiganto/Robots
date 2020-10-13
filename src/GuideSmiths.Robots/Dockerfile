FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
#RUN apt-get update;apt-get install libfontconfig1 -y
ENV LANG es_ES.UTF-8
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src 
COPY . .
RUN dotnet restore GuideSmiths.Robots.sln -nowarn:msb3202,nu1503
WORKDIR /src
RUN dotnet build --no-restore -c Release -o /app 


FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GuideSmiths.Robots.dll"]