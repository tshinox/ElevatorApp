using AutoMapper;
using Elevator.App.Models.DTOs.Requests;
using ElevatorAppData.Models;
using ElevatorAppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAppServices.Implementations
{
    public class LimitCheckService : ILimitCheckService
    {

        public LimitCheckService(ElevatorSystemContext context, IMapper mapper)
        {

        }
        public async Task<bool> CheckPassengerLimit(DestinationRequest request)
        {
            return true;
        }
        public async Task<bool> CheckWeightLimit(DestinationRequest request)
        {
            return true;
        }
    }
}
