using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;

namespace appMedika
{
    class Conexion
    {
        SqlConnection con = new SqlConnection("Initial catalog=BD_DEAS1_MEDIKA;data source=.;uid=sa;pwd=Desarrollo2019"); //Cambiar uid y pwd.
        private SqlCommandBuilder cmb; //Otro cambio.
        public DataSet ds = new DataSet(); //Un cambio más.
        public SqlDataAdapter da;
        public SqlCommand comando;
        public void conectar()
        {
            try
            {
                con.Open();
                MessageBox.Show("Conexion Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar"+ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        public void consulta(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con);
            cmb = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }
        public bool insertar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql,con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else return false;

        }
        public bool Eliminar(string tabla,string condicion)
        {
            con.Open();
            string elimina = "Delete from " + tabla + " where " + condicion;
            comando = new SqlCommand(elimina, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool actualiza(string tabla, string campos, string condicion) {
            con.Open();
            String modifica = "Update " + tabla + " set " + campos +" WHERE "+ condicion;
            comando = new SqlCommand(modifica);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if(i > 0){
                return true;
            }
            else
                return false;

        }

    }
}
