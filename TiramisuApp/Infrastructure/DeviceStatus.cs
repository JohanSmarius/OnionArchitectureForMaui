using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiramisuApp.Services;

namespace TiramisuApp.Infrastructure
{
    public class DeviceStatus : IDeviceStatus
    {
        public Task<bool> IsOnline()
        {
            // Just for the sake of the example, we will always return true
            return Task.FromResult(true);
        }
    }
}
