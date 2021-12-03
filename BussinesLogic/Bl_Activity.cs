using DataAccess;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class Bl_Activity : IB_L_Activity
    {

        public IActivity data { get; set; }

        public Bl_Activity(IActivity data)
        {
            this.data = data;
        }




        public Task<string> Delete(int idActivity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Activity>> get()//int? idActivity
        {
            return await this.data.Get();
        }

        public Task<int> save(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task<int> update(Activity activity, int idActivity)
        {
            throw new NotImplementedException();
        }
    }
}
