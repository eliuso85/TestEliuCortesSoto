using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;


namespace BussinesLogic
{
    public interface IActivityBussiness
    {
        Task<int> save(Activity activity);
        Task<int> update(Activity activity);
        Task<List<Activity>> get(string dateIni, string dateFin, string status);
        Task<List<Activity>> get(int idProperty, DateTime pSchedule);
        Task<string> Delete(int idActivity);
        Task<Activity> GetValidStatus(int idActivity, string Status);
    }
}
