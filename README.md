# MusicMarkt

```
/src
* ApplicationCore
* Infrastructure
* Web

/tests
* UnitTests
```

### Packages
```
/ApplicationCore
install-package Ardalis.Specification

/Infrastructure
install-package Microsoft.EntityFrameworkCore -v 5.0.13
install-package Ardalis.Specification.EntityFrameworkCore
install-package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
install-package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.13

/Web
install-package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
install-package Microsoft.EntityFrameworkCore.Tools -v 5.0.13

```

### Migrations
```
/Infrastructure
add-migration InitialCreate -c MarktContext -s Web -o Data/Migrations
update-database -context MarktContext -s Web
add-migration InitialIdentity -c AppIdentityDbContext -s Web -o Identity/Migrations
update-database -context AppIdentityDbContext -s Web
```



### Resources
* https://github.com/dotnet-architecture/eShopOnWeb
* https://www.postgresql.org
* https://stackoverflow.com/questions/53576485/system-net-sockets-socketexception-on-postgres-connection

# Info

* This project developed as Clean(Onion) Architecture.

