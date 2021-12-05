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
        #region Configuracion
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
        #endregion

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

        public async Task<List<Activity>> Get(string dateIni, string dateFin, string status)
        {

            var pDateI = string.IsNullOrEmpty(dateIni) ? DateTime.Now.AddDays(-3).ToString("dd-MM-yyyy HH:mm:ss") : dateIni;
            var pDateF = string.IsNullOrEmpty(dateIni) ? DateTime.Now.AddDays(15).ToString("dd-MM-yyyy HH:mm:ss") : dateFin;
            var pStatus = string.IsNullOrEmpty(status) ? "Active" : status;

            var pWhere = (string.IsNullOrEmpty(status) ? @"schedule BETWEEN '" + pDateI + "' AND  '" + pDateF + "'" : "status = '" + pStatus + "'");

            var query = @"select * from getListActivities() where " + pWhere;

            var oActivity = (await this.conn().QueryAsync<Activity>(query)).ToList();

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

        public async Task<int> Update(Activity pActivity)
        {
            param.Add("@pid_activity", pActivity.id_activity, DbType.Int32);
            param.Add("@pSchedule", pActivity.schedule, DbType.DateTime);

            var querySp = "call sp_Update_Activity ( @pid_activity, @pSchedule )";
            var result = await this.conn().ExecuteAsync(querySp, param);

            return result;
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

        public async Task<Activity> GetValidStatus(int pActivity, string Status)
        {
            var query = @"select * from activity where id_property = @pActivity and status = @pStatus ";
            param.Add("pActivity", pActivity);
            param.Add("pStatus", Status);
            var oActivity = await this.conn().QueryFirstOrDefaultAsync<Activity>(query, param);
            return oActivity;
        }

    }
}
