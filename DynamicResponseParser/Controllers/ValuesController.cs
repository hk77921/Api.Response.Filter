using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.IO;
using System.Dynamic;
using Newtonsoft.Json.Linq;

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
        //[HttpGet]
        //[MapToApiVersion("1.0")]
        //public dynamic Get()
        //{
        //    var _data = GetDynamicProperties();

        //    return _data;
        //    // return new string[] { "value1", "value2" };
        //}



        [HttpGet]
        [MapToApiVersion("1.0")]
        public dynamic GetuserProfile(string LastName, string DOB)
        {
            var _data = GetUserProfile(LastName, DOB);

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




            // string jsonString = System.IO.File.ReadAllText("data.json");
            string jsonString = System.IO.File.ReadAllText("Users.json");


            //---

            var root = (JContainer)JToken.Parse(jsonString);

            JArray a = JArray.Parse(jsonString);

            //--



            string _json = JsonSerializer.Serialize(jsonString);


           

            JsonNode forecastNode = JsonNode.Parse(jsonString)!;


           


            JsonNode document = JsonNode.Parse(jsonString)!;

            JsonNode _root = document.Root;
            JsonArray uesrArray = _root.AsArray();
         string lastName = "admin";
          string  DOB = "05/11/1966";
            foreach (var item in uesrArray)
            {

                if ((item["last_name"] is not null) && (item["custom_field_1"] is not null))
                {
                   
                    var _lastName = item["last_name"].ToString();
                    var _dob = item["custom_field_1"].ToString();

                    if (_lastName.ToLower().Trim() == lastName.ToLower().Trim() && _dob.Trim() == DOB.Trim())
                    {
                        Console.WriteLine("Record Found");
                        
                    }
                    
                }
             
            }



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

        private dynamic GetUserProfile(string lastName, string DOB)
        {

            var temp = Task.FromResult(GetUserProfileAsyc());

            // Build the logic to filter the user data

            // var _data = GetUserProfile("admin", "05/11/1966");
            lastName = "admin";
            DOB = "05/11/1966";
           // string? _userList = temp.Result.Result;
            JsonNode _userList = JsonNode.Parse(temp.Result.Result)!;

          //  string jsonfile = JsonSerializer.Serialize(_userList);

            var _userProfiles = _userList.AsArray()
                                .Where(i => (i["last_name"].ToJsonString() == lastName)
                                && (i["custom_field_1"].ToJsonString() == DOB));
            // var _user =_userList.Where(i => i["last_name"]==lastName).FirstOrDefault();


            return _userProfiles;


            //string _lastName = "Clark";
            //string _dob = DOB;
            //// string jsonString = System.IO.File.ReadAllText("data.json");
            //string jsonString = System.IO.File.ReadAllText("Users.json");






            //JsonNode forecastNode = JsonNode.Parse(jsonString)!;

            //// var _userProfile = from c in forecastNode.AsArray().Select(i => i["last_name"])
            //// var _userProfiles = from c in forecastNode.AsArray().Where(i => (i["last_name"].ToString() == lastName) && (i["custom_field_1"].ToString() == DOB))
            //var _userProfiles = from c in forecastNode.AsArray().Where(i => (i["last_name"].ToString() == _lastName))
            //                    select new { userProfile = c };


            //foreach (var item in forecastNode.AsArray())
            //{
            //    // Get value from a JsonNode.
            //    JsonNode? lName = item["last_name"];
            //    // Console.WriteLine($"Type={temperatureNode.GetType()}");
            //    Console.WriteLine($"JSON={lName.ToJsonString()}");

            //    // Get a JSON object from a JsonNode.
            //    JsonNode dob = item["custom_field_1"];
            //    // Console.WriteLine($"Type={temperatureRanges.GetType()}");
            //    Console.WriteLine($"avatar={dob.ToJsonString()}");
            //}

            //// Write JSON from a JsonNode
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //// Console.WriteLine(forecastNode!.ToJsonString(options));

            ////// Get value from a JsonNode.
            ////JsonNode lName = forecastNode!["last_name"]!;
            ////// Console.WriteLine($"Type={temperatureNode.GetType()}");
            ////Console.WriteLine($"JSON={lName.ToJsonString()}");

            ////// Get a JSON object from a JsonNode.
            ////JsonNode dob = forecastNode!["custom_field_1"]!;
            ////// Console.WriteLine($"Type={temperatureRanges.GetType()}");
            ////Console.WriteLine($"avatar={dob.ToJsonString()}");



            //dynamic temp = new ExpandoObject();

            ////temp.LastName = lName.ToJsonString();
            ////temp.DOB = dob.ToJsonString();
            ////temp.email = email.ToJsonString();
            ////temp.courses = coursesA.ToJsonString();

            //return temp;





        }

        async Task<string> GetUserProfileAsyc()
        {
            //using var client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();

            //client.BaseAddress = new Uri("https://accredex.talentlms.com/api/v1");
            //var json = await client.GetStringAsync("/users");
            string responseString = string.Empty;
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();

                request.RequestUri = new Uri("https://accredex.talentlms.com/api/v1/users");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Authorization", "Basic SG03U0tjRE5FR1J3OWtZR2NTSFlydHh5azdhTko1Og==");
                HttpResponseMessage response = httpClient.Send(request);

                responseString = await response.Content.ReadAsStringAsync();
                var statusCode = response.StatusCode;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return responseString;
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
