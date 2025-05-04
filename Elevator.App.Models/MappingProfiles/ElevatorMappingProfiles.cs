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

            CreateMap<List<spGetAvailableElevatorsResult>, List<GetAvailableElevatorsResult>>().ReverseMap();
            CreateMap<List<spElevatorRequestResult>, List<GetAvailableElevatorsResult>>().ReverseMap();
            CreateMap<List<spUpdateElevatorStateResult>, List<GetAvailableElevatorsResult>>().ReverseMap();
        }
    }
}
