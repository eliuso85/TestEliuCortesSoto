using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataEntities;
using BussinesLogic;

namespace wApiTRUEHOME.Controllers
{

    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityBussiness activityService;
        private IPropertyBussiness propertyService;
        public ActivityController(IActivityBussiness actividadServices, IPropertyBussiness propertyServices)
        {
            this.activityService = actividadServices;
            this.propertyService = propertyServices;
        }

        [Route("api/Activity")]
        [HttpGet]
        public async Task<List<Activity>> Get()
        {
            return await activityService.get();
        }


        [Route("api/Activity/cancel/{id}")]
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            return await activityService.Delete(id);
        }

        [Route("api/Activity")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Activity pActivity)
        {

            var isActive = await propertyService.GetActivo(pActivity.id_property);
            var result = "";

            if (isActive != null)
            {
                var ValidDates = await activityService.get(pActivity.id_property, pActivity.schedule);

                if (ValidDates != null & ValidDates.Count() > 0)
                {
                    result = "No son Validas las Fechas " + pActivity.schedule + " - " + pActivity.schedule.AddHours(1) + " no se puede agregar Actividades";
                    return NotFound(result);
                }
                else
                {

                    result = (await activityService.save(pActivity)).ToString();
                    return Ok();
                }
            }
            else
            {
                result = "La propiedad esta Desactivada";
                return NotFound(result);
            }

        }
    }
}
