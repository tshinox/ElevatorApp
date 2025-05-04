using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.App.Models.DTOs.Results
{
    public class ElevatorRequestResult
    {
        public int RequestId { get; set; }
        public int? ElevatorId { get; set; }
        public int BuildingId { get; set; }
        public int DirectionId { get; set; }
        public int RequestedFromFloorId { get; set; }
        public int CurrentFloorId { get; set; }
        public int RequestedToFloorId { get; set; }
        public DateTime RequestTime { get; set; }
        public string Status { get; set; }
    }
}
