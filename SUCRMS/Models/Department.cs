using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Department Name")]
        [DisplayName("Department Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Department Code")]
        [StringLength(7, MinimumLength = 2)]
        [DisplayName("Department Code")]
        public string Code { get; set; }
        public int Serials { get; set; }
    }
}