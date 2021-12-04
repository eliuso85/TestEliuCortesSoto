using Dapper;
using DataEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class DataActivity : IActivity
    {
        private DynamicParameters param;

        private PostgresSQLConfiguration dbConnection;

        public DataActivity(PostgresSQLConfiguration connectionStringPGSQL)
        {
            this.dbConnection = connectionStringPGSQL;
            param = new DynamicParameters();
        }

        protected NpgsqlConnection conn()
        {
            return new NpgsqlConnection(dbConnection.ConnectionString);
        }

        public async Task<string> Delete(int pidActivity)
        {
            try
            {
                param.Add("@pID_ACTIVITY", pidActivity, DbType.Int32);
                var querySp = "call SP_cancelActivity (@pID_ACTIVITY)";
                var result = await this.conn().ExecuteAsync(querySp, param);
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Activity>> Get()//int? ACTIVITY_ID = null
        {
            var oActivity = (await this.conn().QueryAsync<Activity>("select * from activity")).ToList();

            return oActivity;
        }

        public async Task<int> Save(Activity act)
        {

            param.Add("@pId_property", act.id_property, DbType.Int32);
            param.Add("@pSchedule", act.schedule, DbType.DateTime);
            param.Add("@pTitle", act.title, DbType.String);

            var querySp = "call sp_new_Activity (@pId_property,@pSchedule,@pTitle)";
            var result = await this.conn().ExecuteAsync(querySp, param);
            return result;

        }

        public Task<Activity> Update(Activity pActivity, int ACTIVITY_ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Activity>> GetValidDates(int idProperty, DateTime dSchedule)
        {
            DateTime pDateAddHour = dSchedule.AddHours(1);
            var query = @"Select * from activity "
                        + " WHERE id_property = " + idProperty +
                        " And schedule BETWEEN '" + dSchedule.ToString("dd-MM-yyyy HH:mm:ss") + "' and '" + pDateAddHour.ToString("dd-MM-yyyy HH:mm:ss") + "'";


            var oActivity = (await this.conn().QueryAsync<Activity>(query)).ToList();

            return oActivity;
        }
    }
}
