using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Contract
{
    public interface IOverheadRepository
    {
        Task<int> ExpanseorIncome(Expanse comp);
        Task<int> ExpanseorIncomeUpdate(Expanse comp);
        Task<Expanse> GetOneOverheadAsync(int id);
        Task<List<Expanse>> GetAllData(int id);
    }
}
