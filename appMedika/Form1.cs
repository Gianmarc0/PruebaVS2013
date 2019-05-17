using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace appMedika
{
    public partial class frm_Distritos_Mantenimiento : Form
    {
        public frm_Distritos_Mantenimiento()
        {
            InitializeComponent();
        }
        Conexion con = new Conexion();
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit(); 
        }

        private void frm_Distritos_Mantenimiento_Load(object sender, EventArgs e)
        {
            con.conectar();
            MostrarDatos();
            dgvRegistro.Columns[0].Width = 80;
        }
        public void MostrarDatos()
        {
            con.consulta("select * from tb_Distritos","tb_Distritos");
            dgvRegistro.DataSource = con.ds.Tables["tb_Distritos"];
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            string cadsql="insert into tb_Distritos values('"+txtnombre.Text+"','"+txtcodigopostal.Text+"')";
            if (con.insertar(cadsql))
            {
                MessageBox.Show("Datos agregados");
                MostrarDatos();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtid.Enabled = false;
            txtnombre.Text = "";
            txtcodigopostal.Text = "";
            txtnombre.Focus();
        }

        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgvRegistro.Rows[e.RowIndex];
            txtid.Text = dgv.Cells[0].Value.ToString();
            txtnombre.Text = dgv.Cells[1].Value.ToString();
            txtcodigopostal.Text = dgv.Cells[2].Value.ToString();
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (con.Eliminar("tb_Distritos","Distritoid="+txtid.Text))

            {
                MessageBox.Show("Registro Eliminado");
                MostrarDatos();
            }
            else
                MessageBox.Show("Error en el Proceso de eliminacion");
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            String actualizar = "Nombre='"+txtnombre.Text +"'CodigoPostal='"+txtcodigopostal.Text+"'";
            if (con.actualiza("tb_Distritos", actualizar, "DistritoId=" + txtid.Text))
            {
                MessageBox.Show("Datos actualizados");
                MostrarDatos();
            }
            else
                MessageBox.Show("Error al actualizar...");
        }

    }
}
