<h1 align="center">Welcome to TravelAgancy 👋</h1>
<p>
  <p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-blue.svg?cacheSeconds=2592000" />
  <img src="https://img.shields.io/badge/SQL%20Server-2019-yellow" />
  <img src="https://img.shields.io/badge/ASP.Net-4.7.2-%23790c91" />
  <a href="https://github.com/JoeGitHubPro/MasterDegree/blob/master/MasterDegreeAPIDecomntation.xlsx" target="_blank">
    <img alt="Documentation" src="https://img.shields.io/badge/documentation-yes-brightgreen.svg" />
  </a>
  <a href="https://github.com/kefranabg/readme-md-generator/graphs/commit-activity](https://github.com/JoeGitHubPro/TravelAgancyPro)" target="_blank">
    <img alt="Maintenance" src="https://img.shields.io/badge/Maintained%3F-yes-green.svg" />
  </a>
  <a href="https://github.com/kefranabg/readme-md-generator/blob/master/LICENSE" target="_blank">
    <img alt="License: ASP.Net" src="https://img.shields.io/github/license/JoeGitHubPro/TravelAgancyPro" />
  </a>
</p>

> The Travel Agency application is used in order to facilitate and streamline the way in which passengers book their bus seats

### 🏠 [Homepage](https://github.com/JoeGitHubPro/TravelAgancyPro)
## Documentation

<div>
	
Click button to get Decomntation sheet or vist home page after deploy
	
[<kbd> <br> Decomntation <br> </kbd>][KBD]



</div>

[KBD]: [Types/KBD.md](https://github.com/JoeGitHubPro/MasterDegree/blob/master/MasterDegreeAPIDecomntation.xlsx)


## Prerequisites

- windows OS 
- .Net Framework 
- SQL Server

## Deploy DataBase

```sh
Run SQL file at this location [https://github.com/JoeGitHubPro/TravelAgancyPro/blob/master/TravelAgancySQLQuery.sql] on database server
```

## Deploy

```sh
Go to  Web.config file , then change connectionStrings 
1- put database server name in "Data Source" 
2- put database name in "Initial Catalog"
3- put server site username in "User Id"
4- put server site password in "password"

do those steps twice for "DefaultConnection" and "MasterDegreeEntities1"
```



## Web.config edition part

```sh

<add name="DefaultConnection" connectionString="Data Source=database server name;Initial Catalog=database name ;User Id=username;Password= password" providerName="System.Data.SqlClient" />
	  <add name="TravelAgancyEntities" connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data Source=database server name;Initial Catalog=database name ;User Id=username;Password= password;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
	
```


## Author

👤 **Youssef Mohamed Ali**

* Website: https://joegithubpro.github.io/Profile/
* Twitter: [@https:\/\/twitter.com\/Y\_mohamed\_Ali?t=uW04TUW-iDrdq0u9GFRm9g&s=09](https://twitter.com/https:\/\/twitter.com\/Y\_mohamed\_Ali?t=uW04TUW-iDrdq0u9GFRm9g&s=09)
* Github: [@JoeGitHubPro](https://github.com/JoeGitHubPro)
* LinkedIn: [@https:\/\/www.linkedin.com\/in\/youssef-mohamed-71a368217](https://linkedin.com/in/https:\/\/www.linkedin.com\/in\/youssef-mohamed-71a368217)

## 🤝 Contributing

Contributions, issues and feature requests are welcome!<br />
## Show your support

Give a ⭐️ if this project helped you!

## 📝 License

Copyright © 2023 [Youssef Mohamed Ali](https://github.com/JoeGitHubPro).<br />
This project is [ASP.Net](https://github.com/kefranabg/readme-md-generator/blob/master/LICENSE) licensed.
