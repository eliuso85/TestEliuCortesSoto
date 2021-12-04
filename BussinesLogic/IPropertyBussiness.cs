using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public interface IPropertyBussiness
    {

     
        //Task<int> save(PROPERTY property);
        //Task<int> update(PROPERTY property, int idProperty);
        //Task<List<PROPERTY>> get();
        //Task<PROPERTY>>get(int idProperty);
        //Task<string> Delete(int idActivity);

        Task<PROPERTY> GetActivo(int pIdProperty);
    }
}
