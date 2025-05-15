using AutoMapper;
using Elevator.App.Models.DTOs.Requests;
using ElevatorAppData.Models;
using ElevatorAppServices.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorAppServices.Implementations
{
    public class LimitCheckService : ILimitCheckService
    {
        private IConfiguration _config;
        private readonly string passengerCon;
        private readonly string weightCon;
        public LimitCheckService(IConfiguration config)
        {
            _config = config;
            passengerCon = _config.GetSection("PassengerLimit").Get<List<List<string>>>();
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