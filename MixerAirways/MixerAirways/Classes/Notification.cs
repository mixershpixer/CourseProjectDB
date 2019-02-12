using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerAirways.Classes
{
    public class Notification
    {
        public string Dep_Time { get; set; }
        public string Dep_City { get; set; }
        public string Arr_City { get; set; }
        public int Not_Code { get; set; }

        public Notification() { }
        public Notification(string _Dep_Time, string _Dep_City, string _Arr_City, int _Not_Code)
        {
            Dep_Time = _Dep_Time;
            Dep_City = _Dep_City;
            Arr_City = _Arr_City;
            Not_Code = _Not_Code;
        }
    }
}
