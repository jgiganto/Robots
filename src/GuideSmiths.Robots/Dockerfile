ARG VERSION=3.1-alpine3.12
 

FROM mcr.microsoft.com/dotnet/core/runtime:$VERSION AS base
ENV LANG en_US.UTF-8
CMD ["/bin/bash"]
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:$VERSION AS build
WORKDIR /src 
COPY . .
RUN dotnet restore GuideSmiths.Robots.sln -nowarn:msb3202,nu1503
WORKDIR /src
RUN dotnet build --no-restore -c Release -o /app 


FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
ENV LANG en_US.UTF-8
CMD ["/bin/bash"]
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GuideSmiths.Robots.dll"]
