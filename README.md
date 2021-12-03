<body style =" font-family:Audiowide; font-size:120%">

# Toll Calculator

---

<br/>

Contains project for unit testing (TollCalculatorTest.csproj) and the actual application (TollCalculator.csproj).

## Application

---

This is a simple Console application to calculate the toll fee for passes in Gothenburg according to current rules. In this application there are no considerations taken for the exeption for passings from Backa (more info can be found at the swedish [transport agency](https://transportstyrelsen.se/sv/vagtrafik/Trangselskatt/Trangselskatt-i-goteborg/undantag-fran-trangselskatt-i-backa/)).

<br/>

**Technologies:**

- .NET Framework 5.0

- C# 9.0 (default)

<br/>

**The objects are:**

- VehicleTypes (enum)
- Calendar (static)
- Passage
- TollDay
- Vehicle
- TollFeeCalculator (static)

And their associations can be seen in the class diagram <a id="back"> [here](#img)</a>

<br/>

## **Nugets**

---

<br/>

### Nager.Date

Used to get weekends and Swedish holidays. Package available via [nuget](https://www.nuget.org/packages/Nager.Date) and [github](https://github.com/nager/Nager.Date).

or install using package manager:

`PM> install-package Nager.Date`

<br/>

## xUnit

For the unit testing.

xUnit ver. 2.4.1.

Package avaliable via [nuget](https://www.nuget.org/packages/xunit/2.4.1) and [github](https://github.com/xunit/xunit) or install using package manager:

` PM> Install-Package xunit -Version 2.4.1`

<br/>

xUnit.runner.visualstudio ver. 2.4.3.

Available via [nuget](https://www.nuget.org/packages/xunit.runner.visualstudio/2.4.3) and [Github](https://github.com/xunit/visualstudio.xunit) or install using package manager:

`PM> Install-Package xunit.runner.visualstudio -Version 2.4.3`

<br/>

### coverlet.collector

Available via [nuget](https://www.nuget.org/packages/coverlet.collector/3.1.0) and [github](https://github.com/coverlet-coverage/coverlet) or install using package manager:

`PM> Install-Package coverlet.collector -Version 3.1.0 `

<br/>

#### Microsoft.NET.Test.Sdk

Ver. 17.0.0. Package available via [nuget](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/17.0.0) and [github](https://github.com/microsoft/vstest/) or install using package:

`PM> Install-Package Microsoft.NET.Test.Sdk -Version 17.0.0`

## Unit testing

**The objects are:**

- CalendarTest (6)
- ProgramTest (8)
- TollDayTest (2)
- TollFeeCalculatorTest (2)

<br/>

<a alt="class diagram" id = "img" alt= "image class diagram" style = "margin-left: auto; margin-right: auto;text-decoration:none;color:pink"><img src= "TollCalculator/ClassDiagram.png" style = "height:50%; width:60%; display: block;
  margin-top:20%" />class diagram</a>

<a style = "color: red;font-weight:1000; font-size:150%;" href = "#back">Up</a>

</body>
