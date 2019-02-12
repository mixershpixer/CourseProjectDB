using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerAirways.Classes
{
    public class Flight
    {
        public int Flight_Id { get; set; }
        public string Dep_Time { get; set; }
        public string Dep_Airport { get; set; }
        public string Dep_City { get; set; }
        public string Aircraft { get; set; }
        public string Arr_Time { get; set; }
        public string Arr_Airport { get; set; }
        public string Arr_City { get; set; }

        public Flight() { }
        public Flight(int _Flight_Id,string _Dep_Time, string _Dep_Airport, string _Dep_City,
             string _Aircraft, string _Arr_Time, string _Arr_Airport, string _Arr_City)
        {
            Flight_Id = _Flight_Id;
            Dep_Time = _Dep_Time;
            Dep_Airport = _Dep_Airport;
            Dep_City = _Dep_City;
            Aircraft = _Aircraft;
            Arr_Time = _Arr_Time;
            Arr_Airport = _Arr_Airport;
            Arr_City = _Arr_City;
        }
    }
}
