# Movie Characters API

## Table of Contents
- [Description](#Description)
- [Install](#Install)
- [Run](#Run)
- [Contributors](#Contributors)

## Description

A solution which creates and interacts with a database of movies, franchises and characters.
It is made using microsoft EF core, in the code-first style.

## Install

Clone or download the repository.
Prerequisites are Visual Studio 2022 with .NET 6.0, and Microsoft Sql Server Management Studio\
Open the solution in Visual Studio. The package dependencies should install automatically.\
Open the file ''AppSettings.json', and change the Data Source in the 'DefaultSelection' to refer to your own database.


Write in the package manager console:
>update-database

## Run

From Visual Studio, run the project. (Hotkey: Ctrl+F5)
This will open a browser window with the Swagger UI, where you can interact with the API.
You can observe changes to the database in Sql Server Management Studio.
## Contributors

Sigurd Riis Haugen @sigurd12345\
Ina Fløysvik Pedersen @inafpedersen