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

        Task<Activity> Update(Activity pActivity, int ACTIVITY_ID);

        Task<List<Activity>> Get();

        Task<List<Activity>> GetValidDates(int idProperty, DateTime pSchedule);

        Task<string> Delete(int ACTIVITY_ID);
    }
}
