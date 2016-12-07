using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();
        public List<Designation> GetAllDesignation()
        {
            return designationGateway.GetAllDesignation();
        }
    }
}