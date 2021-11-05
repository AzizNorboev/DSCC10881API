sudo dotnet restore /var/www/DSCC_10881_API/VideoGameAPI10881/VideoGameAPI10881.csproj
sudo dotnet publish -c release /var/www/DSCC_10881_API/VideoGameAPI10881/VideoGameAPI10881.csproj -o /var/www/DSCC_10881_API_build/
systemctl enable webapi.service
systemctl start webapi.service