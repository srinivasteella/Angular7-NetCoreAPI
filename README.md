# Angular7-NetCoreAPI ![GitHub release](https://img.shields.io/github/release/srinivasteella/Angular7-NetCoreAPI.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2019.svg?style=for-the-badge)


#### Car Sales Demo Application - Frontend in Angular 7 and Backend in .netCore2.1 

| ![GitHub Release Date](https://img.shields.io/github/release-date/srinivasteella/Angular7-NetCoreAPI.svg?style=plastic) | [![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1) |[![Node](https://img.shields.io/badge/Node-Js-blue.svg?style=plastic)](https://nodejs.org/en/download/) | ![GitHub language count](https://img.shields.io/github/languages/count/srinivasteella/Angular7-NetCoreAPI.svg) | ![GitHub top language](https://img.shields.io/github/languages/top/srinivasteella/Angular7-NetCoreAPI.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/srinivasteella/Angular7-NetCoreAPI.svg) 
| ---          | ---        | ---      | ---        |  --- | --- |

---------------------------------------


## Repository codebase
 
The complete app has divided into 2 folders.

The repository consists of projects as below:


| # |Project Name | Project detail | location| Environment |
| ---| ---  | ---           | ---          | --- |
| 1 | Vehcile.Sale.Demo | Asp.Net Core2.1 WebApi as backend  | Within Server folder | [![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1)|
| 2 | Vehcile.Sale.Demo.Test | Unit Test for webapi | Within Server folder | [![.Net Framework](https://img.shields.io/badge/DotNet-2.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/2.1)| 
| 3 | N.A. | Angular app as frontend | Within Client folder | [![.Net Framework](https://img.shields.io/badge/Node-Js-blue.svg?style=plastic)](https://nodejs.org/en/download/)| 


### Summary

The overall objective of the applications is to make an API that allows to manage vehicles and open to suppoert new vehicle types with minimal code changes.
```
>	Add vehicle
>	Update vehicle
>	Get a specific vehicle
>	Get vehicle properties
>	Get all vehicle types
>	Unit test
>	Integration test
```

### Setup detail

##### Environment Setup detail

> Download/install   	

>   1. [![VS2017](https://img.shields.io/badge/VS-2017-blue.svg)](https://git-scm.com/downloads) 
>	2. [![.Net Framework](https://img.shields.io/badge/.Net%20Core-2.1-blue.svg)](https://www.microsoft.com/net/download/dotnet-core/2.1) to run webapi project
>	2.  [![.Net Framework](https://img.shields.io/badge/Node-Js-blue.svg)](https://www.microsoft.com/net/download/dotnet-core/2.1) to run angulat application project

##### Project Setup detail

>   1. Please clone or download the repository from [![github](https://img.shields.io/badge/git-hub-blue.svg?style=plastic)](https://github.com/srinivasteella/Angular7-NetCoreAPI) 

>   
##### (a) To start the backend webapi service
   
>   1. Open solution in **Visual Studio 2017** and press F5 to run the API 
>   
>   2. Or Alternatively browse to following path 		  **Angular7-NetCoreAPI\Vehcile.Sale.Demo\bin\Debug\netcoreapp2.1** 
>   3. `shift+right click` and select **Open command window here**
>
>   4. Run `dotnet VehicleSale.Demo.dll` on the terminal
>   
>   5. **Server** [backend webapi service] shall start running on port **5000**
>   6. Access the API from here : http://localhost:5000
==========================================================================   
![Swagger](https://github.com/srinivasteella/Angular7-NetCoreAPI/blob/master/swagger.JPG "Webapi")
==========================================================================
##### b) To start the front end application
>  Within Visual Studio Code Open a new command terminal 
>  
>  Within the new terminal, browse to the folder named as "client"
>  
>  To restore the dependencies, type npm install on the terminal
>  
>  Now in order to run the angular application (front end application), type npm start on the terminal
>  
>  Shortly a browser shall open with url as localhost:5050
>  
> Please note - No items will be loaded initially as the application is using in-memory data storage. Therefore, please add some vehicles.


##### homepage { landing page }
==========================================================================
![Home](https://github.com/srinivasteella/Angular7-NetCoreAPI/blob/master/Home.JPG "Angular")



##### Add page 
=========================================================================

![Add](https://github.com/srinivasteella/Angular7-NetCoreAPI/blob/master/Add.JPG "Angular")

##### (c) To run the unit test project
>   1. Open solution in **Visual Studio 2017**
>   
>   2. Goto Test -> Windows -> Test Explorer
>   
>   3. Click on **Run All**

```
For better experience please chrome browser
```

