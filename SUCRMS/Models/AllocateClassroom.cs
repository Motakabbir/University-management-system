using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class AllocateClassroom
    {
        public int AcrId { get; set; }
        [DisplayName("Course")]
        public int CourseId { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Room")]
        public int RoomId { get; set; }
        [DisplayName("Day")]
        public int DayId { get; set; }
        [DisplayName("Time From")]
        [Required(ErrorMessage = "TimeFrom Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        
        public DateTime TimeFrom { get; set; }
        [DisplayName("Time To")]
        [Required(ErrorMessage = "TimeFrom Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime TimeTo { get; set; }
        public int Status { get; set; }

        public Course Course { get; set; }
        public Room Room { get; set; }
        public Day Day { get; set; }
    }
}