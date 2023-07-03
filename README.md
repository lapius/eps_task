# EPS_Task

**Entity Framework Core with Blazor**

Welcome to my .NET project that uses Entity Framework Core with Blazor Server.

## Installation

To install and run the project, follow these steps:

1. Clone the repository to your local machine.
2. Ensure you have [ISS Express](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-configure-iis-express-for-project-url) configured.
3. Update the default connection string in `appsettings.json` file to `"Server=localhost\\SQLEXPRESS; Database=eps_codes; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True"`. This is necessary for establishing a secure connection.
4. Open the Package Manager Console in Visual Studio.
5. Navigate to the `Server` folder using the following command: `cd Server`.
6. Apply the migrations to update the database by running the command: `dotnet ef database update`.

## Usage

The project includes a navigation panel on the left side with the following features:

1. **Generate Codes**: Enter the count of codes you want to generate and the desired length. Click the "Generate" button to generate the codes. You will receive a success message if the generation is successful.

2. **Use Code**: Enter a code to check if it is valid. If the code is correct, you will receive a success message. If the code is incorrect or already used, you will receive an appropriate error message.

3. **Discount Codes**: This section displays a list of all generated codes. It includes information such as the ID, usage status, creation date, and usage date of each code.

Feel free to explore these features and interact with the application.

## License

This project is licensed under the [MIT License](LICENSE).

## Authors

- [Marijus Lapinskas](https://github.com/lapius)