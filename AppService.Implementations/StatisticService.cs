using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.Interfaces;

namespace AppService.Implementations
{
    public class StatisticService : IStatisticService
    {
        public Task WriteStatisticAsync(string area, int id)
        {
            return Task.CompletedTask;
        }

        public Task WriteStatisticAsync(string area, IEnumerable<int> ids)
        {
            return Task.CompletedTask;
        }
    }
}