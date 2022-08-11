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
    [RoutePrefix("api/Promociones")]
    [Authorize]
    public class PromocionesController : ApiController
    {
        private DAPromociones dapromo;

        public PromocionesController()
        {
            dapromo = new DAPromociones();
        }



        [HttpPost]
        [Route("guardarPromocion")]
        public IHttpActionResult guardarPromocion(ENPromociones paramss)
        {
            try
            {
                var rpt = dapromo.guardarPromocion(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("listaPromociones")]
        public IHttpActionResult listaPromociones(ENPromociones paramss)
        {
            try
            {
                var rpt = dapromo.listaPromociones(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("eliminarPromociones")]
        public IHttpActionResult eliminarPromociones(ENPromociones paramss)
        {
            try
            {
                var rpt = dapromo.eliminarPromociones(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("obtEditarPromo")]
        public IHttpActionResult obtEditarPromo(ENPromociones paramss)
        {
            try
            {
                var rpt = dapromo.obtEditarPromo(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("editarPromocion")]
        public IHttpActionResult editarPromocion(ENPromociones paramss)
        {
            try
            {
                var rpt = dapromo.editarPromocion(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
