# DotNetCoreDemo

Some things to remember:

* When creating a new .Net Core project, choose the ASP.NET Core option in Visual Studio. 
* When creating a class library, choose the .Net Standard option.
* When using Sql in your class library, make sure to add a reference to the Nuget package for System.Data.SqlClient
* All JS files now go under the wwwroot/js folder
* When referencing the JS files, just use the following `<script src='/js/{myjsfile.js} />`
* Connection strings are now stored in the `appsettings.json` file. You can see a preview here: https://github.com/LITW06/DotNetCoreDemo/blob/master/WebApplication17/appsettings.json#L8-L10
* To access the connection string, your controller needs to take in an `IConfiguration` instance. See here: https://github.com/LITW06/DotNetCoreDemo/blob/master/WebApplication17/Controllers/FileUploadController.cs#L52-L55

Things you need to do to enable session:

https://github.com/LITW06/DotNetCoreDemo/blob/master/WebApplication17/Startup.cs#L27
https://github.com/LITW06/DotNetCoreDemo/blob/master/WebApplication17/Startup.cs#L48

