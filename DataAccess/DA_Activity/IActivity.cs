using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataEntities;

namespace DataAccess
{
    public interface IActivity
    {
        Task<int> Save(Activity act);
        Task<int> Update(Activity pActivity);
        Task<List<Activity>> Get(string dateIni, string dateFin, string status);
        Task<List<Activity>> GetValidDates(int idProperty, DateTime pSchedule);
        Task<string> Delete(int ACTIVITY_ID);
        Task<Activity> GetValidStatus(int pActivity, string Status);

    }
}
