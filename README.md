# 🚗 DVLD - Driving & Vehicle License Management System

This is a multi-layered **.NET WinForms desktop application** for managing the operations of a **Drivers and Vehicles License Department (DVLD)**. The system is designed based on a complete requirements document and provides full control over issuing, renewing, and managing driving licenses, users, and related services.

## 📂 Project Structure

The application follows a **three-tier architecture**:
- **Presentation Layer**: Windows Forms (UI)
- **Business Logic Layer (BLL)**: Application logic
- **Data Access Layer (DAL)**: Handles interaction with the database

## ✅ Features

### 🪪 License Services
- Issue new license (first-time)
- Renew expired licenses
- Replace lost or damaged licenses
- Issue international licenses
- Unblock previously blocked licenses

### 📑 License Application Flow
- Supports different license classes (motorcycles, cars, commercial vehicles, trucks, etc.)
- Validates age and existing licenses
- Tracks license application status
- Associates each license to a unique person (based on National ID)

### 👨‍🔧 Tests & Requirements
- Eye test, written test, and driving test (in order)
- Manages test schedules and results
- Prevents progression if a test is failed

### 👥 User & Person Management
- Add, update, or delete system users and general persons
- Each user is linked to a person by National ID
- Role-based access (permissions can be assigned per user)

### 📋 Request Management
- Create, view, update, cancel, or filter requests
- All request types (issue, renew, replace, international, etc.)
- Service-specific fees

### 🔐 Admin Capabilities
- Add, delete, freeze system users
- Manage license classes and test types
- View action logs (track who did what and when)

## 🔧 Technologies Used

- **.NET Framework (WinForms)**
- **C#**
- **ADO.NET / SQL Server** (for data access)
- **Multi-layered architecture (3 tiers)**