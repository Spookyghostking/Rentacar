## Rentacar
This is the repository for my final project for the ITAcademy Microsoft Development course.
It uses the ASP.NET core MVC framework, and since it's basically just a toy project it runs locally and is not set up for anything more serious.
It is not the greatest thing ever created or anything, but it is a thing that exists c:
### Installation
After you download the repository, you can open the Rentacar.sln file in Visual Studio.
You will need ASP.NET and web developnet tools (Tools > Manage Tools and Features...).
If you launch the app at that point you will notice that it might not be working correctly.
This is because the app is not connected to a database yet.

In order to connect it to a database you will have to edit the connection string in the appsettings.json file and change it to a valid Microsoft SQL Server connection

After that is done, it is time to actually create the database. For this we will use the Microsoft.EntityFrameworkCore.Tools package.
Write `update-database` in the Package Manager Console (View > Other Windows > Package Manager Console if it is not open).
Once this is done, the database will be created and the app can be launched.

Note that the first user to register will be given admin privileges.
### Features
- A user is able to register and log in
- Users can make a reservation for when they want to rent their desired vehicle
- The admins can add, remove, and manage vehicles, reservations, roles, and so on...

