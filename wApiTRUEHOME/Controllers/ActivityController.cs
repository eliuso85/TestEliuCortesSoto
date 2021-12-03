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
        private IB_L_Activity activityService;
        public ActivityController(IB_L_Activity actividadServices)
        {
            this.activityService = actividadServices;
        }


        [Route("api/Activity")]
        [HttpGet]
        public async Task<List<Activity>> Get()
        {
            return await activityService.get();
        }

    }
}
