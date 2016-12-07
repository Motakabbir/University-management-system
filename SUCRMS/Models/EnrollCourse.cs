using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class EnrollCourse
    {
        public int EcId { get; set; }
        [DisplayName("Student Reg. No")]
        public int StudenId { get; set; }
        [DisplayName("Course")]
        public int CourseId { get; set; }

        public DateTime Date { get; set; }
    }
}