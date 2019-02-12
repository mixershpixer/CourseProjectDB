using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerAirways.Classes
{
    public class Book
    {
        public string Bookdate { get; set; }
        public string Dep_Airport { get; set; }
        public string Dep_City { get; set; }
        public string Dep_Time { get; set; }
        public string Aircraft { get; set; }
        public string Arr_Airport { get; set; }
        public string Arr_City { get; set; }
        public string Arr_Time { get; set; }
        public int Seat_No { get; set; }
        public string Fare_Cond { get; set; }
        public int Price { get; set; }
        public int Flight_Id { get; set; }

        public Book() { }
        public Book(string _Bookdate, string _Dep_Airport, string _Dep_City, 
            string _Dep_Time, string _Aircraft, string _Arr_Airport, string _Arr_City, string _Arr_Time,
            int _Seat_No, string _Fare_Cond, int _Price, int _Flight_Id)
        {
            Bookdate = _Bookdate;
            Dep_Airport = _Dep_Airport;
            Dep_City = _Dep_City;
            Dep_Time = _Dep_Time;
            Aircraft = _Aircraft;
            Arr_Airport = _Arr_Airport;
            Arr_City = _Arr_City;
            Arr_Time = _Arr_Time;
            Seat_No = _Seat_No;
            Fare_Cond = _Fare_Cond;
            Price = _Price;
            Flight_Id = _Flight_Id;
        }
    }
}
