# Solomon's Advice Web App

![Solomon's Advice](https://via.placeholder.com/800x200.png?text=Solomon%27s+Advice)

Welcome to Solomon's Advice, a web application designed to provide users with meaningful advice on various topics. This application allows users to register, explore, and interact with a variety of pieces of advice, making it a valuable tool for anyone looking for guidance or just a bit of wisdom in their day.

## 🎯 Features

- **Random Advice**: Get random advice with just one click.
- **Search by Keywords**: Look for specific advice based on keywords or phrases.
- **User Registration & Profile**: Create an account, save your favorite advice, and manage your profile.
- **Admin Area**: Manage content and user roles efficiently with the built-in admin panel.

## 🛠️ Technologies Used

- **ASP.NET Core MVC**: The foundation of the web application.
- **Entity Framework Core**: For database interactions.
- **Microsoft Identity**: Handling user authentication and authorization.
- **SQL Server**: Primary database for storing advice and user data.
- **Bootstrap**: For responsive design and styling.

## 🚀 Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/SolomonsAdviceWebApp.git
   cd SolomonsAdviceWebApp

2. **Ensure your SQL Server is running**:
    Ensure your SQL Server is running
    Update the connection string in appsettings.json if necessary.
    Run the migrations to set up the database:
   ```bash
   dotnet ef database update
   
3. **Run the application**
   ```bash
    dotnet run

**Seeding Roles and Users**
The application includes a seed method to create default roles and users. Upon first run, these roles will be created automatically.

##📸
![Home Page](img/homepage.png)


##🤝 Contributing
We welcome contributions! Please fork this repository, make your changes, and submit a pull request. For major changes, open an issue first to discuss what you would like to change.


##📧 Contact
If you have any questions or want to connect, feel free to reach out:

Email: kawangcmelo@gmail.com
LinkedIn: [Your LinkedIn Profile](https://www.linkedin.com/in/kawanmelo/)
