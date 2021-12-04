﻿using DataAccess;
using DataEntities;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class ActivityData : IActivityBussiness
    {

        public IActivity data { get; set; }
        public ActivityData(IActivity data)
        {
            this.data = data;
        }



        public async Task<string> Delete(int idActivity)
        {
            return await this.data.Delete(idActivity);
        }

        public async Task<List<Activity>> get()//int? idActivity
        {
            return await this.data.Get();
        }

        public async Task<List<Activity>> get(int idProperty, DateTime pSchedule)
        {
            return await this.data.GetValidDates(idProperty, pSchedule);
        }

        public async Task<int> save(Activity activity)
        {

            return await this.data.Save(activity);
        }

        public async Task<int> update(Activity activity, int idActivity)
        {
            throw new NotImplementedException();
        }
    }
}
