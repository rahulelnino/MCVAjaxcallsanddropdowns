using mvcalligator.Helper;
using mvcalligator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcalligator.Controllers
{
    [CustomExceptionFilter]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                
                using (HotelManagmentEntities1 db = new HotelManagmentEntities1())
                {
                    User usr = db.Users.Where(w => w.UserId == user.UserId && w.Password == user.Password).FirstOrDefault();
                    if (usr != null)
                    {
                        Session["username"] = usr.Id;
                        return RedirectToAction("RoomListing");
                    }
                    
                }
            }
            
            return View(user);
        }

        public ActionResult RoomListing()
        {
            IEnumerable<RoomModel> roomModel;
            HotelManagmentEntities1 db = new HotelManagmentEntities1();

            roomModel = db.Rooms.Join(db.ChckIns, r => r.RoomNo, cin => cin.RoomNo, (r, cin) => new RoomModel
            {
                Roomno = r.RoomNo,
                Roomtype = r.RoomType,
                checkindate = cin.CheckinDate,
                guestname = cin.GuestName,
                isVacant = r.IsVacant == true ? "Yes" : "No"
                    
                });
            
            return View(roomModel);
        }
    }
}