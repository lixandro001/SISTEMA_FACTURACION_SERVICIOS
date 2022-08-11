using CNTI365.FACTUR.ENTITY.Parametros;
using CNTI365.FACTUR.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNTI365.FACTUR.DATOS
{
    public class DAInventario
    {
        public ResponseInventario AgregarInventario(ENInventario paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseInventario>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_AgregarInventario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idproducto", paramss.idproducto));
                    cmd.Parameters.Add(new SqlParameter("@idempleado", paramss.idempleado));
                    cmd.Parameters.Add(new SqlParameter("@cantexisten", paramss.masexistencias));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseInventario();
                            resul.response = Convert.ToString(rdr["response"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
