using CNTI365.FACTUR.DATOS;
using CNTI365.FACTUR.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CNTI365.FACTUR.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Inventarios")]
    [Authorize]
    public class InventariosController : ApiController
    {

        private DAInventario dainvent;

        public InventariosController()
        {
            dainvent = new DAInventario();
        }



        [HttpPost]
        [Route("AgregarInventario")]
        public IHttpActionResult AgregarInventario(ENInventario paramss)
        {
            try
            {
                var rpt = dainvent.AgregarInventario(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
