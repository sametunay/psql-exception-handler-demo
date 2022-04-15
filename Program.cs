global using System;
using ExceptionTest;
using ExceptionTest.Data;
using ExceptionTest.Services;

var cString = "Host=localhost; Port=5432; Database=exception-test; User Id=root; Password=root;";
var service = new Service(new DbOperations(new Context(cString)));

service.Test();

Console.ReadLine();
