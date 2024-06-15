Deployment commands

```code
az login
dotnet build
dotnet publish -c Release -r linux-x64 --self-contained -o ./publish
cd publish
zip -r ../myapp.zip .
cd ..
az webapp deployment source config-zip --resource-group PrintMe --name PrintMeAPI --src myapp.zip
```
