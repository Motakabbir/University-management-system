using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class ClassSchedule
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
    }
}