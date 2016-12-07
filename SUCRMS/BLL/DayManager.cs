using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class DayManager
    {
        DayGateway dayGateway = new DayGateway();
        public List<Day> GetAllDay()
        {
            return dayGateway.GetAllDay();
        }
    }
}