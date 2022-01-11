# LogExtractor
Extracts out the logs from the specified file and logs out unique ip addresses, most active ip addresses, and most visited urls.

Requires .NET 6.

The main project is contained in LogExtractor, and the unit tests are stored in LogExtractor.Test.

## How to run
An argument stating the path of where the file is located is needed. There is a log file in this repo LogExtractor/assets/programming-task-example-data.

Hence you can use your IDE to execute the project with the argument, or use the following command with dotnet cli  at the root folder:

```
 dotnet restore
 dotnet build
 dotnet run --project LogExtractor .\LogExtractor\assets\programming-task-example-data.log
```

## Test
There are three unit tests cases for calculating the three respective values.

Tests case can be executed via your IDE or with the dotnet cli command at the root folder:
```
  dotnet test
```