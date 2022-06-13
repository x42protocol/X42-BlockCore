#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Node/Blockcore.Node/Blockcore.Node.csproj", "Node/Blockcore.Node/"]
COPY ["Features/Blockcore.Features.NodeHost/Blockcore.Features.NodeHost.csproj", "Features/Blockcore.Features.NodeHost/"]
COPY ["Blockcore/Blockcore.csproj", "Blockcore/"]
COPY ["Networks/Blockcore.Networks.XRC/Blockcore.Networks.XRC.csproj", "Networks/Blockcore.Networks.XRC/"]
COPY ["Features/Blockcore.Features.MemoryPool/Blockcore.Features.MemoryPool.csproj", "Features/Blockcore.Features.MemoryPool/"]
COPY ["Features/Blockcore.Features.Consensus/Blockcore.Features.Consensus.csproj", "Features/Blockcore.Features.Consensus/"]
COPY ["Networks/Blockcore.Networks.Bitcoin/Blockcore.Networks.Bitcoin.csproj", "Networks/Blockcore.Networks.Bitcoin/"]
COPY ["Networks/BlockCore.Networks.Cybits/Blockcore.Networks.Cybits.csproj", "Networks/BlockCore.Networks.Cybits/"]
COPY ["Networks/Blockcore.Networks.BCP/Blockcore.Networks.BCP.csproj", "Networks/Blockcore.Networks.BCP/"]
COPY ["Networks/Blockcore.Networks.Impleum/Blockcore.Networks.Impleum.csproj", "Networks/Blockcore.Networks.Impleum/"]
COPY ["Features/Blockcore.Features.Diagnostic/Blockcore.Features.Diagnostic.csproj", "Features/Blockcore.Features.Diagnostic/"]
COPY ["Networks/Blockcore.Networks.Stratis/Blockcore.Networks.Stratis.csproj", "Networks/Blockcore.Networks.Stratis/"]
COPY ["Networks/Blockcore.Networks.SeniorBlockCoin/Blockcore.Networks.SeniorBlockCoin.csproj", "Networks/Blockcore.Networks.SeniorBlockCoin/"]
COPY ["Networks/Blockcore.Networks.City/Blockcore.Networks.City.csproj", "Networks/Blockcore.Networks.City/"]
COPY ["Networks/Blockcore.Networks.Rutanio/Blockcore.Networks.Rutanio.csproj", "Networks/Blockcore.Networks.Rutanio/"]
COPY ["Networks/Blockcore.Networks.X1/Blockcore.Networks.X1.csproj", "Networks/Blockcore.Networks.X1/"]
COPY ["Features/Blockcore.Features.Miner/Blockcore.Features.Miner.csproj", "Features/Blockcore.Features.Miner/"]
COPY ["Features/Blockcore.Features.RPC/Blockcore.Features.RPC.csproj", "Features/Blockcore.Features.RPC/"]
COPY ["Features/Blockcore.Features.Wallet/Blockcore.Features.Wallet.csproj", "Features/Blockcore.Features.Wallet/"]
COPY ["Features/Blockcore.Features.BlockStore/Blockcore.Features.BlockStore.csproj", "Features/Blockcore.Features.BlockStore/"]
COPY ["Networks/Blockcore.Networks.Xds/Blockcore.Networks.Xds.csproj", "Networks/Blockcore.Networks.Xds/"]
COPY ["Features/Persistence/Blockcore.Features.Persistence.LevelDb.CorePackage/Blockcore.Features.Persistence.LevelDb.CorePackage.csproj", "Features/Persistence/Blockcore.Features.Persistence.LevelDb.CorePackage/"]
COPY ["Features/Persistence/Blockcore.Features.BlockStore.Persistence.LevelDb/Blockcore.Features.BlockStore.Persistence.LevelDb.csproj", "Features/Persistence/Blockcore.Features.BlockStore.Persistence.LevelDb/"]
COPY ["Features/Persistence/Blockcore.Persistence.LevelDb/Blockcore.Persistence.LevelDb.csproj", "Features/Persistence/Blockcore.Persistence.LevelDb/"]
COPY ["Features/Persistence/Blockcore.Features.Consensus.Persistence.LevelDb/Blockcore.Features.Consensus.Persistence.LevelDb.csproj", "Features/Persistence/Blockcore.Features.Consensus.Persistence.LevelDb/"]
COPY ["Features/Persistence/Blockcore.Features.Base.Persistence.LevelDb/Blockcore.Features.Base.Persistence.LevelDb.csproj", "Features/Persistence/Blockcore.Features.Base.Persistence.LevelDb/"]
COPY ["Networks/Blockcore.Networks.RoyalSportsCity/Blockcore.Networks.RoyalSportsCity.csproj", "Networks/Blockcore.Networks.RoyalSportsCity/"]
COPY ["Features/Blockcore.Features.Notifications/Blockcore.Features.Notifications.csproj", "Features/Blockcore.Features.Notifications/"]
COPY ["Networks/Blockcore.Networks.OpenExo/Blockcore.Networks.OpenExo.csproj", "Networks/Blockcore.Networks.OpenExo/"]
COPY ["Features/Blockcore.Features.Dns/Blockcore.Features.Dns.csproj", "Features/Blockcore.Features.Dns/"]
COPY ["Features/Blockcore.Features.ColdStaking/Blockcore.Features.ColdStaking.csproj", "Features/Blockcore.Features.ColdStaking/"]
COPY ["Networks/Blockcore.Networks.HomeCoin/Blockcore.Networks.HomeCoin.csproj", "Networks/Blockcore.Networks.HomeCoin/"]
COPY ["Networks/Blockcore.Networks.x42/Blockcore.Networks.x42.csproj", "Networks/Blockcore.Networks.x42/"]
COPY ["Networks/Blockcore.Networks.SERF/Blockcore.Networks.SERF.csproj", "Networks/Blockcore.Networks.SERF/"]
COPY ["Features/x42.Features.xServer/x42.Features.xServer.csproj", "Features/x42.Features.xServer/"]
COPY ["Features/Persistence/Blockcore.Features.Persistence.Rocksdb.CorePackage/Blockcore.Features.Persistence.Rocksdb.CorePackage.csproj", "Features/Persistence/Blockcore.Features.Persistence.Rocksdb.CorePackage/"]
COPY ["Features/Persistence/Blockcore.Features.Base.Persistence.RocksDb/Blockcore.Features.Base.Persistence.RocksDb.csproj", "Features/Persistence/Blockcore.Features.Base.Persistence.RocksDb/"]
COPY ["Features/Persistence/Blockcore.Persistence.RocksDb/Blockcore.Persistence.RocksDb.csproj", "Features/Persistence/Blockcore.Persistence.RocksDb/"]
COPY ["Features/Persistence/Blockcore.Features.Consensus.Persistence.RocksDb/Blockcore.Features.Consensus.Persistence.RocksDb.csproj", "Features/Persistence/Blockcore.Features.Consensus.Persistence.RocksDb/"]
COPY ["Features/Persistence/Blockcore.Features.BlockStore.Persistence.RocksDb/Blockcore.Features.BlockStore.Persistence.RocksDb.csproj", "Features/Persistence/Blockcore.Features.BlockStore.Persistence.RocksDb/"]
COPY ["Networks/Blockcore.Networks.Strax/Blockcore.Networks.Strax.csproj", "Networks/Blockcore.Networks.Strax/"]
COPY ["Features/Blockcore.Features.WalletWatchOnly/Blockcore.Features.WalletWatchOnly.csproj", "Features/Blockcore.Features.WalletWatchOnly/"]
COPY . .
RUN dotnet restore "Node/Blockcore.Node/Blockcore.Node.csproj"

WORKDIR "/src/Node/Blockcore.Node"
RUN dotnet build "Blockcore.Node.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blockcore.Node.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blockcore.Node.dll"]