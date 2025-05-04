using Elevator.App.Models.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAppServices.Interfaces
{
    public interface IProximityCheckService
    {
        Task<string> GetClosestElevator(FloorRequest request);
    }
}
