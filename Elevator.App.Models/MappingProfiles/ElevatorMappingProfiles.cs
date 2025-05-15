using AutoMapper;
using Elevator.App.Models.DTOs.Results;
using ElevatorAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.App.Models.MappingProfiles
{
    public class ElevatorMappingProfiles : Profile
    {
        public ElevatorMappingProfiles()
        {
            CreateMap<spGetAvailableElevatorsResult, GetAvailableElevatorsResult>();
            CreateMap<spElevatorRequestResult, ElevatorRequestResult>();
            CreateMap<spUpdateElevatorStateResult, UpdateElevatorStateResult>();
        }
    }
}
