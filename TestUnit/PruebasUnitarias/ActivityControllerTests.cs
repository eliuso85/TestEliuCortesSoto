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

            #region Preparación

            var filter = new Filters();
            var controller = new ActivityController(this.activityService, this.propertyService);
            #endregion
            #region Ejecución
            var respuesta = await controller.Get(filter);

            var resultado = respuesta;

            #endregion
            #region Verificación
            Assert.AreEqual(respuesta.Count, resultado.Count);
            #endregion

        }

        [TestMethod]
        public async Task obtenerListaActividadeConFiltros()
        {

            #region Preparación

            var filter = new Filters();

            filter.status = "Active";
            var controller = new ActivityController(this.activityService, this.propertyService);
            #endregion
            #region Ejecución
            var respuesta = await controller.Get(filter);

            var resultado = respuesta;

            #endregion
            #region Verificación
            Assert.AreEqual(respuesta.Count, resultado.Count);
            #endregion

        }

        [TestMethod]
        public async Task cancelaciondeActividades()
        {

            #region Preparación

            var controller = new ActivityController(this.activityService, this.propertyService);
            #endregion
            #region Ejecución
            var respuesta = await controller.Delete(2);
            #endregion
            #region Verificación
            Assert.AreEqual("1", respuesta);
            #endregion

        }



    }
}
