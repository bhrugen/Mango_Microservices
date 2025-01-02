## Introduction to .NET Microservices (.NET 8)
#### This repository is a part of my this youtube tutorial
[![image](https://github.com/user-attachments/assets/d12789ec-1d4a-4682-b939-ea9765a1e9e2)](https://www.youtube.com/embed/Nw4AZs1kLAs?si=e-w9CAzRPsTtrMpd)

# Mango Microservices

Mango Microservices is a project demonstrating the implementation of microservices architecture using .NET technologies. This repository contains multiple services, each responsible for a specific domain within the overall system.

## Table of Contents
- [Overview](#overview)
- [Key Features](#key-features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Contributing](#contributing)

## Overview

This project is structured to showcase how to create and manage microservices using various .NET technologies, including ASP.NET Core, Entity Framework Core, and Ocelot for API Gateway.

## Key Features

- Multiple independent services.
- Centralized API Gateway using Ocelot.
- Deployment to Azure.
- Integration with SQL Server.
- Production-ready configurations.

## Technologies Used

- C#
- ASP.NET Core
- Entity Framework Core
- Ocelot API Gateway
- SQL Server
- Azure

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

- .NET SDK
- SQL Server
- Azure account (for deployment)

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/bhrugen/Mango_Microservices.git
   ```
2. Navigate to each service directory and restore the dependencies
   ```sh
   dotnet restore
   ```
3. Update the database connection strings in the `appsettings.json` files.

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

For more details, visit the [repository](https://github.com/bhrugen/Mango_Microservices).

```

You can add this content directly to the `README.md` file in your repository.
