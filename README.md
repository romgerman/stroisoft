# Run

### Install dependencies
```
cd ClientApp
npm install
cd ..
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

### Debug
```
dotnet run
```

### Deploy
```
dotnet publish --configuration Release
cd bin\Release\netcoreapp2.2\publish
dotnet stroisoft.dll
```