using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Models.Interface
{
    public interface IOrderService
    {
        public Task<List<OutOrder>> GetOrders();
    }
}
