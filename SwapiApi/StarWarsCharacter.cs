using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapiApi
{
    public class StarWarsCharacter
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string HomeWorld { get; set; }

        public override string ToString()
        {
            return $"{Name, -10}{Height, 10}{Mass, -10}{HairColor, -10}{EyeColor,-10}{BirthYear, -10}{Gender, -10}{HomeWorld, -10}";
        }
    }
}
