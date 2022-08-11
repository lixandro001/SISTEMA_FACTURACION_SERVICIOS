﻿using BAZ.GEN.Log4Dan;
using CNTI365.FACTUR.DATOS;
using CNTI365.FACTUR.ENTITY.Parametros;
using CNTI365.FACTUR.Service.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CNTI365.FACTUR.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {

        private DALogin dalogin;
        private Log Log = new Log(typeof(LoginController));
       

        public LoginController()
        {
            dalogin = new DALogin();
            
        }

        [HttpPost]
        [Route("Acceder")]
        public IHttpActionResult Acceder(ENLogin paramss)
        {
            try
            {

                var ex = "";

                if (paramss == null)
                {
                    ex = "No se enviaron datos desde la web";
                    Log.WriteLogError(ex);
                }

                var rpt = dalogin.Authenticate(paramss);

                if (rpt.responsetoken == "exitoso" || rpt.responsetoken == "ok")
                {
                     rpt = dalogin.Acceder(paramss);

                    if (rpt.response == "ok")
                    {
                        var token = TokenGenerator.GenerarTokenJwt(paramss.proyecto);
                        rpt.responsetoken = token;
                        return Ok(rpt);
                    }
                    else
                    {
                        return Ok(rpt);
                    }

                }
                else
                {
                    return Ok(rpt);
                }


            }
            catch (Exception ex)
            {
                Log.WriteLogError(ex.Message);
                throw ex;
            }
        }



    }




}
