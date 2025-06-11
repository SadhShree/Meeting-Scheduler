# Meeting-Scheduler
# 📅 Outlook Calendar Integration

A modern, full-stack calendar application that integrates with Outlook, built with Angular 17 and .NET 9.

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Angular](https://img.shields.io/badge/Angular-17.2.0-red.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)

## ✨ Features

- 📆 Full calendar view with day, week, and month layouts
- 🔄 Seamless integration with Outlook Calendar
- ⚡ Real-time updates and synchronization
- 🎨 Modern Material Design UI
- 🔒 Secure authentication with JWT
- 📱 Responsive design for all devices

## 🛠️ Technology Stack

### Frontend
- Angular 17
- Angular Material UI
- FullCalendar Integration
- RxJS for state management
- TypeScript
- Moment.js for date handling

### Backend
- .NET 9 Web API
- Entity Framework Core
- PostgreSQL Database
- Clean Architecture
- JWT Authentication
- Swagger/OpenAPI documentation

## 🚀 Getting Started

### Prerequisites
- Node.js (Latest LTS version)
- .NET 9 SDK
- PostgreSQL
- Angular CLI

### Installation

1. **Clone the repository**
   ```bash
   git clone [your-repository-url]
   cd [repository-name]
   ```

2. **Backend Setup**
   ```bash
   cd OutlookCalendar.API
   dotnet restore
   dotnet run
   ```
   The API will be available at `https://localhost:7001`

3. **Frontend Setup**
   ```bash
   cd frontend
   npm install
   ng serve
   ```
   Navigate to `http://localhost:4200`

## 🏗️ Project Structure

```
├── frontend/                # Angular frontend application
│   ├── src/                # Source files
│   ├── public/             # Public assets
│   └── ...
├── OutlookCalendar.API/    # .NET Web API
├── OutlookCalendar.Core/   # Business logic and interfaces
├── OutlookCalendar.Domain/ # Domain entities and logic
└── OutlookCalendar.Infrastructure/ # Data access and external services
```

## 🔧 Configuration

1. Update the database connection string in `appsettings.json`
2. Configure Outlook API credentials in the appropriate configuration file
3. Adjust CORS settings if needed

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Authors

- [SADHA SHREE RAMESH] - *Initial work*

## 🙏 Acknowledgments

- FullCalendar for the excellent calendar component
- Angular Material team for the UI components
- Microsoft for .NET and Outlook API
