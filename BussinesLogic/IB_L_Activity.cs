using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;


namespace BussinesLogic
{
    public interface IB_L_Activity
    {
        Task<int> save(Activity activity);
        Task<int> update(Activity activity, int idActivity);
        Task<List<Activity>> get();
        Task<string> Delete(int idActivity);

    }
}
