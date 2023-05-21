// See https://aka.ms/new-console-template for more information

using DynamicExpresso;
using Extendable;

var helloRequests = new List<HelloRequest>
{
    new()
    {
        Name = "me",
        Date = new Date { Day = 1, Month = 2, Year = 1970 }
    },
    new()
    {
        Name = "you",
        Date = new Date { Day = 1, Month = 1, Year = 1970 }
    }
};

var equalDate = "1970-02-01";

// Verify equality comparison works
Console.WriteLine(helloRequests[0].Date == equalDate);
Console.WriteLine(helloRequests[1].Date == equalDate);

// Verify equality comparison works in LINQ
Console.WriteLine(helloRequests.Where(request => request.Date == equalDate).ToList());

// Try the same with expresso
var interpreter = new Interpreter().Reference(typeof(Extendable.Date));
var whereFunction = interpreter.ParseAsDelegate<Func<HelloRequest, bool>>($"""request.Date == "{equalDate}" """, "request");

Console.WriteLine(helloRequests.Where(whereFunction).ToList());

Console.ReadLine();