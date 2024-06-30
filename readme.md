# ACCOUNT SERVICE
The microservice *Account* for the [e-commerce microservice](https://gitlab.com/HarimbolaSantatra/ecommerce-microservices).
It's a REST API.

## Setup development environment
### Docker
Run the container with:

    ./docker.sh "172.17.0.1"

The script takes one optional argument: the host of the database. If it is no provided, *172.17.0.1* is used (a random default gateway for a docker container).
It compiles the code, build the image and then run the container on locahost.

### Dotnet
To simply run it on dotnet CLI: `dotnet run`. It will be exposed on *localhost*, port 5010.

### Reset the database
To reset the database and the migration, run `./reset-migration.sh`.

## Setup production environment
Visit the [master repo][1] to view instructions.

## API Usage
### Exposed endpoint
Here's a list of all exposed endpoint of the API:
Endpoint | HTTP Method | Description | Method
--- | --- | --- | ---
`/` | get | Test if the service is working | Get
`accounts` | get | Get all existing account | GetAllAccounts
`account/<userId>` | get | Get one user's account | GetAccount
`account/add` | post | Add a user account (See body data below) | AddAccount
`account/delete?userId=3` | get | Delete a user account | DeleteAccount

### Body data
#### AddAccount
```json
{
    "Id": 3,
    "Username": "Gal"
}
```

### About the project
- Database: mariadb
- Database name: *account_microservice*

---
[1]: https://gitlab.com:HarimbolaSantatra/ecommerce-microservices
