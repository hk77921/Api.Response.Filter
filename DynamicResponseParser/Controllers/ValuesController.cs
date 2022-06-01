using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.IO;
using System.Dynamic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicResponseParser.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public dynamic Get()
        {
            var _data = GetDynamicProperties();

            return _data;
            // return new string[] { "value1", "value2" };
        }


        [HttpGet("{name}")]
        [MapToApiVersion("2.0")]

        public dynamic GetList()
        {
            var _data = GetDynamicProperties();

            return _data;
        }
        private dynamic GetDynamicProperties()
        {

            // JObject data = JObject.Parse(File.ReadAllText(MyFilePath));




            string jsonString = System.IO.File.ReadAllText("data.json");

            JsonNode forecastNode = JsonNode.Parse(jsonString)!;

            // Write JSON from a JsonNode
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Console.WriteLine(forecastNode!.ToJsonString(options));

            // Get value from a JsonNode.
            JsonNode temperatureNode = forecastNode!["avatar"]!;
            // Console.WriteLine($"Type={temperatureNode.GetType()}");
            Console.WriteLine($"JSON={temperatureNode.ToJsonString()}");

            // Get a JSON object from a JsonNode.
            JsonNode avatar = forecastNode!["avatar"]!;
            // Console.WriteLine($"Type={temperatureRanges.GetType()}");
            Console.WriteLine($"avatar={avatar.ToJsonString()}");

            // Get a JSON object from a JsonNode.
            JsonNode email = forecastNode!["email"]!;
            /// Console.WriteLine($"Type={temperatureRanges.GetType()}");
            Console.WriteLine($"email={email.ToJsonString()}");
            // Get a JSON object from a JsonNode.
            JsonNode id = forecastNode!["id"]!;
            // Console.WriteLine($"Type={temperatureRanges.GetType()}");
            Console.WriteLine($"id={id.ToJsonString()}");



            // Get a JSON object from a JsonNode.
            JsonNode coursesA = forecastNode!["courses"]!;
            // Console.WriteLine($"Type={temperatureRanges.GetType()}");
            Console.WriteLine($"coursesA={coursesA.ToJsonString()}");

            dynamic temp = new ExpandoObject();

            temp.id = id.ToJsonString();
            temp.avatar = avatar.ToJsonString();
            temp.email = email.ToJsonString();
            temp.courses = coursesA.ToJsonString();

            return temp;

            //// Get a JSON object from a JsonNode.
            //JsonNode ?courses = forecastNode["courses"]!["id"];
            //// Console.WriteLine($"Type={temperatureRanges.GetType()}");
            //Console.WriteLine($"courses.id={courses.ToJsonString()}");

            //// Get a JSON object from a JsonNode.
            //JsonNode? coursesC = forecastNode["courses"]!["completed_on"];
            //// Console.WriteLine($"Type={temperatureRanges.GetType()}");
            //Console.WriteLine($"courses.completed_on={coursesC.ToJsonString()}");







        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
