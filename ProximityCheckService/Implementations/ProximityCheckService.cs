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
    public class ProximityCheckService : IProximityCheckService
    {
        private readonly ElevatorSystemContext _context;

        private readonly IMapper _mapper;

        public ProximityCheckService(ElevatorSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> GetClosestElevator(FloorRequest request)
        {
            return "";
        }
    }
}
