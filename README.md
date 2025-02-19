## **LoanSimPriceAPI**

This project is an API implementation in .NET using ASP.NET Core, designed for loan simulation based on the Price amortization method. It provides endpoints to calculate fixed installments, interest, amortization, and outstanding balance over time. The API enables efficient and precise loan simulations, making it ideal for financial applications requiring detailed payment schedules.

## Features

- List all posts
- Get posts by ID
- Create a new post
- Update an existing post
- Delete a post

## Requirements

- .NET SDK (version 8.0.0)
- Visual Studio or Visual Studio Code

## Getting Started

1. Clone the repository:

   ```shell
   git clone git@github.com:Lelisvaldo/LoanSimPriceAPI.git
   ```

2. Open the project in your preferred development environment.

3. Build the project to restore dependencies:

   ```shell
   dotnet build
   ```

4. Run the project:

   ```shell
   dotnet run
   ```

5. The API will be accessible at:
   ```shell
      "https://localhost:[port]/api"
   ```

## API Endpoints *

- **GET /** – Get the API status
- **GET /api/loans** – Get all loan simulations
- **GET /api/loans/{id}** – Get a loan simulation by ID
- **POST /api/loans** – Create a new loan simulation
- **PUT /api/loans/{id}** – Update a loan simulation
- **DELETE /api/loans/{id}** – Delete a loan simulation

## Contributing

Contributions are welcome! If you find any issues or want to add new features, feel free to open an issue or submit a pull request.

## License

Distributed under the MIT License.