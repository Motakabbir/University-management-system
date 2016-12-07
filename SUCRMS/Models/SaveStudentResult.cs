using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class SaveStudentResult
    {
        public int ResultId { get; set; }
        public int CourseId { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        [DisplayName("Student Reg. No")]
        public int StudentId { get; set; }

    }
}