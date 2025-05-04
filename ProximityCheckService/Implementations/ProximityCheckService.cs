using AutoMapper;
using Elevator.App.Models.DTOs.Requests;
using Elevator.App.Models.DTOs.Results;
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
        public async Task<List<GetAvailableElevatorsResult>> GetClosestElevator(FloorRequest request)
        {
            var result = await _context.GetProcedures().spGetAvailableElevatorsAsync(request.FloorNo, "Main");
            return _mapper.Map<List<GetAvailableElevatorsResult>>(result);
        }
    }
}
