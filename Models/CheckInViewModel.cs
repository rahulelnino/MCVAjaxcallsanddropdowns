using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcalligator.Models
{
    public class CheckInViewModel
    {
        public List<int> RoomNos { get; set; }

        [Required(ErrorMessage ="This is a Required field")]
        public string RoomType { get; set; }

        [Required(ErrorMessage = "This is a Required field")]
        public string GuestName { get; set; }

        
        public int MobileNumber { get; set; }

        [Required(ErrorMessage = "This is a Required field")]
        public string CheckInDate { get; set; }
        
        public string CheckOutDate { get; set; }
        
        public string Address { get; set; }

        [Required(ErrorMessage = "This is a Required field")]
        public string Purpose { get; set; }

        [Required(ErrorMessage = "This is a Required field")]
        public int Deposit { get; set; }

        [Required(ErrorMessage = "This is a Required field")]
        public int Rent { get; set; }
    }
}