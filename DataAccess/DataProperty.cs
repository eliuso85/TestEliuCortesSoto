using Dapper;
using DataEntities.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataProperty : IProperty
    {

        private DynamicParameters param;

        private PostgresSQLConfiguration dbConnection;

        public DataProperty(PostgresSQLConfiguration connectionStringPGSQL)
        {
            this.dbConnection = connectionStringPGSQL;
            param = new DynamicParameters();
        }

        protected NpgsqlConnection conn()
        {
            return new NpgsqlConnection(dbConnection.ConnectionString);
        }

        //public Task<string> Delete(int pIdProperty)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<List<PROPERTY>> Get()
        //{
        //    var oPROPERTY = (await this.conn().QueryAsync<PROPERTY>("select * from PROPERTY")).ToList();

        //    return oPROPERTY;
        //}
        public async Task<PROPERTY> GetActivo(int pIdProperty)
        {

            var oActivity = (await this.conn().
                                   QueryFirstOrDefaultAsync<PROPERTY>
                                   ("select id_property, status from property where id_property = @pIdProperty and status='ACTIVE'", new { pIdProperty = pIdProperty }));

            return oActivity;
        }

        //public Task<int> Save(PROPERTY act)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<PROPERTY> Update(PROPERTY Property, int pIdProperty)
        //{
        //    throw new NotImplementedException();
        //}

      
    }
}
