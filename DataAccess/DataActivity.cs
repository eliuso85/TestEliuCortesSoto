using Dapper;
using DataEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class DataActivity : IActivity
    {
        private DynamicParameters param;

        private PostgresSQLConfiguration conn;

        public DataActivity(PostgresSQLConfiguration connectionStringPGSQL)
        {
            this.conn = connectionStringPGSQL;
            param = new DynamicParameters();
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(conn.ConnectionString);
        }





        public Task<string> Delete(int ACTIVITY_ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Activity>> Get()//int? ACTIVITY_ID = null
        {
            var oActivity = (await this.dbConnection().QueryAsync<Activity>("select * from activity")).ToList();

            return oActivity;
        }

        public Task<int> Save(Activity act)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> Update(Activity pActivity, int ACTIVITY_ID)
        {
            throw new NotImplementedException();
        }
    }
}
