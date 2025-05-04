using Elevator.App.Models.DTOs.Requests;
using Elevator.App.Models.DTOs.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAppServices.Interfaces
{
    public interface IElevatorStateService
    {
        Task<ElevatorStateResult> GetElevatorStatus(ElevatorStateRequest request);
        Task<int> GetDestination(ElevatorStateRequest request);
    }
}
