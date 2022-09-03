using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiApi;

namespace Client
{
    class Program
    {
        static NetworkManager manager = new NetworkManager();
        static SwapApiConfiguration config = new SwapApiConfiguration();
        static StarWarsCharacter GetCharacter(JToken token)
        {
            StarWarsCharacter character = new StarWarsCharacter
            {
                Name = token["name"].ToString(),
                Height = token["height"].ToString(),
                Mass = token["mass"].ToString(),
                HairColor = token["hair_color"].ToString(),
                EyeColor = token["eye_color"].ToString(),
                BirthYear = token["birth_year"].ToString(),
                Gender = token["gender"].ToString()
            };
            string json = manager.GetJson($"{token["homeworld"]}");
            JObject res = JObject.Parse(json);
            character.HomeWorld = res["name"].ToString();
            return character;
        }

        static void Main(string[] args)
        {
            string url = $"{config.BaseUrl}people/";
            string json = manager.GetJson(url);

            JObject res = JObject.Parse(json);

            string next = res["next"].ToString();
            while(next != "")
            {
                IList < JToken > resultJson = res["results"].Children().ToList();
                foreach(JToken item in resultJson)
                {
                    Console.WriteLine(GetCharacter(item).ToString() + "\t");
                }
                json = manager.GetJson(next);
                res = JObject.Parse(json);
                next = res["next"].ToString();
            }
        }
    }
}
