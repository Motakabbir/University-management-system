using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGateway allocateClassroomGateway = new AllocateClassroomGateway();
        public int Save(AllocateClassroom allocateClassroom)
        {
            if (IsScheduleExist(allocateClassroom.TimeFrom, allocateClassroom.TimeTo))
            {
                throw new Exception("The Time Schedule already exists or partially overlapping!");
            }
            return allocateClassroomGateway.Save(allocateClassroom);
        }

        public bool IsScheduleExist(DateTime timeFrom, DateTime timeTo)
        {
            return allocateClassroomGateway.IsScheduleExist(timeFrom, timeTo);
        }

        public int UnAllocateClassrooms(AllocateClassroom allocateClassroom)
        {
            // throw new NotImplementedException();

            return allocateClassroomGateway.UnallocationClassRoomGetway(allocateClassroom);
        }
    }
}