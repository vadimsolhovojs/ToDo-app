# ✅ Simple TODO List App 📝

This is a simple TODO list app created using .NET Core MVC with SQL Server for data storage.

## Features

- Add new TODO items
- Delete existing TODO items
- Mark TODO items as completed
- Delete all items at once

## Technologies Used

- .NET Core MVC
- Entity Framework Core for data access
- SQL Server for database storage
- Vue.js for basic data binding

## Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/vadimsolhovojs/ToDo-app.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd ToDo-app
   ```

3. **Update the connection string:**

   Update the connection string in `appsettings.json` to point to your SQL Server instance.

4. **Run the database migrations:**

   ```bash
   dotnet ef database update
   ```

5. **Build and run the project:**

   ```bash
   dotnet run
   ```

   Access the application in your web browser at `http://localhost:5000`.

## Usage

1. **Add a new TODO item:**

   Enter the item in the input field and click the "Add" button.

2. **Mark a TODO item as completed:**

   Check the checkbox next to the item.

3. **Delete a TODO item:**

   Click the rubbish bin icon next to the item.

## Contributing

Contributions are welcome! If you have any suggestions, feature requests, or bug reports, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
