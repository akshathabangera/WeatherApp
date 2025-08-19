using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public string Localtime { get; set; }
    }

    public class Current
    {

        public Condition Condition { get; set; }
        public double Temp_C { get; set; }

    }

    public class Condition
    {
        public string Text { get; set; }

        public int Code { get; set; }
    }

}
