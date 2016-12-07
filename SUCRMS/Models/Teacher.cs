using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please provide Email")]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Contact No")]
        [DisplayName("Contact No")]
        public double ContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Designation")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select Designation")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please provide Credit")]
        [DisplayName("Credit to be Taken")]
        public double CreditTobeTaken { get; set; }
        [DisplayName("Remaining Credit")]
        public double RemainingCredit { get; set; }
        public int Serials { get; set; }
    }
}