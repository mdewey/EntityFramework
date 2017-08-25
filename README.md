### for requirements in csprog:
Add the following references to your code

``` XML
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0" />
    <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="2.0.0" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.0.0" PrivateAssets="All" />
  </ItemGroup>
  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
    <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.0" />
    <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0" />
  </ItemGroup>
```


### Restore
dotnet restore

in console
`dotnet ef` to make sure it works

### Create database
// create database using pgcli
`createdb blogger`

// Only do once and on dev machine
// create user 
createuser dev
\password dev
psql netblog2 

ALTER USER dev WITH SUPERUSER;

### Create context

create dbcontext
```
dotnet ef dbcontext scaffold "Host=localhost;Database=netblog;Username=dev;Password=dev" Npgsql.EntityFrameworkCore.PostgreSQL
```
### create classes
Model your data using POCO


### Create/Update Database
add & run migration