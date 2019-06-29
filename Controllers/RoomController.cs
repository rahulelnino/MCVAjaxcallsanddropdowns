using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcalligator.Models;
namespace mvcalligator.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult CheckIn()
        {
            using(HotelManagmentEntities1 db = new HotelManagmentEntities1())
            {
                CheckInViewModel chinobj = new CheckInViewModel();
                chinobj.RoomNos = db.Rooms.Select(S => S.RoomNo).ToList();
                
                List<SelectListItem> rooms = new List<SelectListItem>()
                {
                    new SelectListItem {Text="--Please Select" , Value=""}
                };
                foreach(int item in chinobj.RoomNos)
                {
                    
                    rooms.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
                }
                ViewBag.Roomnos = rooms;
            }
            return View();
        }

        public JsonResult getRoomType(string id)
        {
            int Id = Convert.ToInt32(id);
            using (HotelManagmentEntities1 db = new HotelManagmentEntities1())
            {
                string roomtype = db.Rooms.Where(w=>w.RoomNo == Id).Select(s=>s.RoomType).FirstOrDefault().ToString();
                return Json(roomtype.Trim(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CheckIn(CheckInViewModel chckin)
        {
            bool isvacant = false;
            int roomno = chckin.RoomNos[0];
            Room room;
            using(HotelManagmentEntities1 db = new HotelManagmentEntities1())
            {
                isvacant = db.Rooms.Where(w => w.RoomNo == roomno).Select(s => s.IsVacant).FirstOrDefault();
                room = db.Rooms.Where(w => w.RoomNo == roomno).FirstOrDefault();
                if (isvacant)
                {
                    ChckIn chkin = new ChckIn()
                    {
                        RoomNo = roomno,
                        GuestName = chckin.GuestName,
                        CheckinDate = chckin.CheckInDate.ToString(),
                        PurposeOfVisit = chckin.Purpose,
                        Deposit = chckin.Deposit,
                        RoomRent = chckin.Rent
                    };
                    room.IsVacant = false;
                    db.ChckIns.Add(chkin);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("RoomListing", "Login");
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