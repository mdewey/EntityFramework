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
`createdb superblog`

// Only do once and on dev machine
// create user 

``` bash
createuser dev
psql blogger
```
Inside pgcli

```bash
\password dev
ALTER USER dev WITH SUPERUSER;
```

### Create context

create dbcontext
```
dotnet ef dbcontext scaffold "Host=localhost;Database=blogger;Username=dev;Password=dev" Npgsql.EntityFrameworkCore.PostgreSQL
```

### Add to startup.cs

``` c#
 services.AddDbContext<bloggerContext>();
```


### create classes
Model your data using POCO


### Create/Update Database
add & run migration


### Access in Controller
add the following to a controller, its a private method and a ctor

```
private readonly bloggerContext _context;

public HomeController(bloggerContext context)
{
    _context = context;
}

```