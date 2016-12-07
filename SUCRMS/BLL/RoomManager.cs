using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class RoomManager
    {
        RoomGatewy roomGatewy = new RoomGatewy();
        public List<Room> GetAllRoom()
        {
            return roomGatewy.GetAllRoom();
        }
    }
}