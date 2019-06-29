using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcalligator.Models
{
    public class RoomModel
    {
        public int Roomno { get; set; }

        public string Roomtype { get; set; }

        public string guestname { get; set; }

        public string checkindate { get; set; }

        public string isVacant { get; set; }

    }
}