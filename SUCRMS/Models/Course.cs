using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Course Name")]
        
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please provide Course Credit")]
        [Range(0.5,5.0)]
        [DisplayName("Credit")]
        public double Credit { get; set; }
        [Required(ErrorMessage = "Please provide Course Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select Departmet")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Semester")]
        [DisplayName("Semister")]
        public int SemesterId { get; set; }
        public string Semester { get; set; }
        public string TeacherName { get; set; }
        public int Serials { get; set; }
    }
}