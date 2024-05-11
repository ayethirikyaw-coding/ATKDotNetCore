using ATKDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");


//ConsoleApp - Client (Frondend)
//ASP.NET CORE Web API - Server (backend)

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();
