using System.Collections.Generic;
using System.Threading.Tasks;
using MSP.Services.Model;

namespace MSP.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
    }
}
