using Microsoft.Extensions.Configuration;
using System;

namespace JsonConfigSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("class.json");

            var configuration = builder.Build();

            Console.WriteLine($"ClassNo:[{configuration["ClassNo"]}]");
            Console.WriteLine($"ClassName:[{configuration["ClassName"]}]");

            Console.WriteLine($"Students");

            Console.Write(configuration["Students:0:Name"]);
            Console.WriteLine(configuration["Students:0:Age"]);
            Console.Write(configuration["Students:1:Name"]);
            Console.WriteLine(configuration["Students:1:Age"]);

            Console.ReadLine();
        }
    }
}
