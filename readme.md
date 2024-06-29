# ACCOUNT SERVICE
The microservice *Account* for the [e-commerce microservice](https://gitlab.com/HarimbolaSantatra/ecommerce-microservices).
It's a REST API.

## Setup
### Developpement installation
#### Docker
Run the container with:

    ./docker.sh

This script compile the code, build the image and then run the container on locahost using the database *192.168.56.1*.

#### Dotnet
To simply run it on dotnet CLI: `dotnet run`. It will be exposed on *localhost*, port 5010.

### Production installation
For a more robust installation, run on docker and specify the *DB_HOST* environment variable manually.

An example of a production script is:

    dotnet publish --output /out
    docker build -t account_mcs
    docker run -itd \
        -p 5010:8080 \
        --rm \
        --name account_mcs \
        --env DB_HOST="192.168.56.1" \
        account_mcs

### Reset the database
To reset the database and the migration, run `./reset-migration.sh`.

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
