# School Management API

## Project Description

This project is a **School Management API** built with **ASP.NET Core** and includes an **Angular frontend**. It is designed to facilitate CRUD operations related to student academic records, focusing on managing student marks. The API allows users to create, read, update, and delete records in a database. It supports managing student data, subjects, and scores, along with calculating and ranking students based on their results.

---

## Features

- **Student CRUD**: Create, Read, Update, and Delete student records.
- **Subject CRUD**: Create, Read, Update, and Delete subjects.
- **Marks CRUD**: Create, Read, Update, and Delete student marks.
- **Ranking**: Rank students based on their marks and calculate their positions.
- **API Integration**: Exposes API endpoints for managing student records, subjects, and marks.
- **Angular Frontend**: Simple interface to interact with the API and perform operations.

---

## Tech Stack

- **Backend**: ASP.NET Core Web API
- **Frontend**: Angular
- **Database**: SQL Server (or other relational databases)
- **ORM**: Entity Framework Core

---

## Prerequisites

To run this project, ensure you have the following installed:

- **.NET SDK**: 6.0 or higher
- **Node.js**: 14.x or higher
- **Angular CLI**: Latest version (can be installed via `npm install -g @angular/cli`)
- **SQL Server**: Or any other relational database system

---

## Getting Started

Follow these steps to set up the project on your local machine:

### 1. Clone the Repository

```bash
git clone [https://github.com/yourusername/SchoolManagementAPI.git](https://github.com/VishalAnan/SchoolManagement.git)
cd SchoolManagement/API
```

### 2. Restore the dependencies
```bash
dotnet restore
```
### 3. Run Script and Change appsettings.json
```
Open Db.sql and Run the scipt
Change Connection Stirng in appsettings.json to your database
```
### 4. Run Project
```bash
dotnet run
```
## Getting Started For Frontend

### 1. Navigate to the Angular project folder:

```bash
cd ClientApp
```
### 2. Install frontend dependencies

```bash
npm install
```
### 3. Run the Angular application

```bash
ng serve
```
