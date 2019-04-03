using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheAnimalConsole.model
{
    //A model structure of .NET object to parse the JSON Object
    public class JsonDataFormat
    {
        public string Data { get; set; }
        public JsonDataFormat Yes { get; set; }
        public JsonDataFormat No { get; set; }
    }
}
