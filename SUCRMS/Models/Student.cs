using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DisplayName("Contact No")]
        public double ContactNo { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string RegistrationId { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public int Serials { get; set; }
    }
}