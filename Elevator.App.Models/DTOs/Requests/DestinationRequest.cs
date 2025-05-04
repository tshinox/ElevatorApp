using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.App.Models.DTOs.Requests
{
    public class DestinationRequest
    {
        public int Destination {  get; set; }
        public int Passengers { get; set; }
        public decimal Weight {  get; set; } 
    }
}
