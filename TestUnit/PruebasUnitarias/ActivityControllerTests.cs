using BussinesLogic;
using Dapper;
using DataAccess.test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System.Threading.Tasks;
using wApiTRUEHOME.Controllers;
using DataEntities.Models.Filters;

namespace wApiTRUEHOME.test.PruebasUnitarias.Activity
{
    [TestClass]
    public class ActivityControllerTests
    {
        #region Configuracion
        private DynamicParameters param;

        private PostgresSQLConfiguration dbConnection;

        public ActivityControllerTests(PostgresSQLConfiguration connectionStringPGSQL)
        {
            this.dbConnection = connectionStringPGSQL;
            param = new DynamicParameters();
        }
        protected NpgsqlConnection conn()
        {
            return new NpgsqlConnection(dbConnection.ConnectionString);
        }
        #endregion

        private IActivityBussiness activityService;
        private IPropertyBussiness propertyService;
        public ActivityControllerTests(IActivityBussiness actividadServices, IPropertyBussiness propertyServices)
        {
            this.activityService = actividadServices;
            this.propertyService = propertyServices;
        }
        [TestMethod]
        public async Task obtenerListaActividadesinFiltros()
        {

            #region Preparaci�n

            var filter = new Filters();
            var controller = new ActivityController(this.activityService, this.propertyService);
            #endregion
            #region Ejecuci�n
            var respuesta = await controller.Get(filter);

            var resultado = respuesta;

            #endregion
            #region Verificaci�n
            Assert.AreEqual(respuesta.Count, resultado.Count);
            #endregion

        }

        [TestMethod]
        public async Task obtenerListaActividadeConFiltros()
        {

            #region Preparaci�n

            var filter = new Filters();

            filter.status = "Active";
            var controller = new ActivityController(this.activityService, this.propertyService);
            #endregion
            #region Ejecuci�n
            var respuesta = await controller.Get(filter);

            var resultado = respuesta;

            #endregion
            #region Verificaci�n
            Assert.AreEqual(respuesta.Count, resultado.Count);
            #endregion

        }

        [TestMethod]
        public async Task cancelaciondeActividades()
        {

            #region Preparaci�n

            var controller = new ActivityController(this.activityService, this.propertyService);
            #endregion
            #region Ejecuci�n
            var respuesta = await controller.Delete(2);
            #endregion
            #region Verificaci�n
            Assert.AreEqual("1", respuesta);
            #endregion

        }



    }
}
