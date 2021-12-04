using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IProperty
    {
        //Task<int> Save(PROPERTY act);
        //Task<PROPERTY> Update(PROPERTY Property, int pIdProperty);
        //Task<List<PROPERTY>> Get();
        Task<PROPERTY> GetActivo(int pIdProperty);
        //Task<string> Delete(int pIdProperty);
    }
}
