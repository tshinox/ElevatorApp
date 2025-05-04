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
    public class ElevatorStateService : IElevatorStateService
    {
        private readonly ElevatorSystemContext _context;

        private readonly IMapper _mapper;

        public ElevatorStateService(ElevatorSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ElevatorStateResult> GetElevatorStatus(ElevatorStateRequest request)
        {
            return new ElevatorStateResult();
        }

        public async Task<int> GetDestination(ElevatorStateRequest request)
        {
            return 0;
        }
    }
}
