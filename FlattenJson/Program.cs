using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace FlattenJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string testData = GetData();

            Console.WriteLine("==================== flatten System.Text.Json.JsonDocument ====================");
            var flattenJsonDocument = JsonDocument.Parse(testData).Flatten();
            foreach (var item in flattenJsonDocument)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            Console.WriteLine("==================== flatten Newtonsoft.Json.Linq.JContainer ====================");
            var jContainer = JToken.Parse(testData) as JContainer;
            var flattenJContainer = jContainer?.Flatten();
            foreach (var item in flattenJContainer)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            Console.ReadLine();
        }

        private static string GetData()
        {
            return @"
[
  [
    {
	  ""id"": 1,
	  ""name"": ""Ron"",
	  ""projects"": [
	    {
		  ""projectName"": ""p1"",
		  ""released"": true
		},
		{
		  ""projectName"": ""p2"",
		  ""released"": false
		}
	  ],
	  ""teamMembers"": [""Alan"", ""Bob"", ""Doris""]
	},
    {
	  ""id"": 2,
	  ""name"": ""John"",
	  ""projects"": [
	    {
		  ""projectName"": ""p3"",
		  ""released"": false
		},
		{
		  ""projectName"": ""p4"",
		  ""released"": true
		}
	  ],
	  ""teamMembers"": [""Emma"", ""Alma"", ""Patrick""]
	}
  ],
  [
    {
	  ""id"": 3,
	  ""name"": ""Dan"",
	  ""projects"": [
	    {
		  ""projectName"": ""p5"",
		  ""released"": true
		},
		{
		  ""projectName"": ""p6"",
		  ""released"": true
		}
	  ],
	  ""teamMembers"": [""James""]
	},
	{
	  ""id"": 4,
	  ""name"": ""Dao"",
	  ""projects"": [
	    {
		  ""projectName"": ""p7"",
		  ""released"": false
		},
		{
		  ""projectName"": ""p8"",
		  ""released"": false
		}
	  ],
	  ""teamMembers"": [""Alice"", ""Mark""]
	}
  ]
]
";
        }
    }
}
