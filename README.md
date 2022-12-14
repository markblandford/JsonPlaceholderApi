# {JSON} Placeholder C# API

A minimal, C# API using [JSONPlaceholder](https://jsonplaceholder.typicode.com/) fake data.


## Running

```shell
  dotnet run --project JsonPlaceholderApi
```

The API will then be available at [https:localhost:3000](https:localhost:3000) (or [http:localhost:3001](http:localhost:3001)).

Swagger documentation is available at [/swagger](https:localhost:3000/swagger)

### API Interface

| API              | Description       | Response Body |
|------------------|-------------------|---------------|
| `GET /user`      | Get all users     | `IList<User>` |
| `GET /user/{id}` | Get a users by ID | `User`        |

## Tests

Use the standard, `dotnet test` command to run the [XUnit](https://xunit.net/) unit tests.
