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
    public partial class frm_NuevoMantenimiento : Form
    {
        public frm_NuevoMantenimiento()
        {
            InitializeComponent();
        }

        Conexion con = new Conexion();

        private void NuevoMantenimiento_Load(object sender, EventArgs e) {

            con.conectar();
            MostrarDatos();
        }

        public void MostrarDatos() {
            con.consulta("select * from tb_Especialidades", "tb_Especialidades");
            dgvDatos.DataSource = con.ds.Tables["tb_Especialidades"];
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            string cadsql = "insert into tb_Especialidades values('" + txtID.Text + "','" + txtNombre.Text + "')";
            if (con.insertar(cadsql))
            {
                MessageBox.Show("Datos agregados");
                MostrarDatos();
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            DataGridViewRow dgv = dgvDatos.Rows[e.RowIndex];
            txtID.Text = dgv.Cells[0].Value.ToString();
            txtNombre.Text = dgv.Cells[1].Value.ToString();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (con.Eliminar("tb_Especialidades", "IdEspecialidad=" + txtID.Text)) {
                MessageBox.Show("Registro Eliminado");
                MostrarDatos();
            }
            else
                MessageBox.Show("Error en el Proceso de eliminacion");
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            String actualizar = "ID='" + txtID.Text + "'Nombre='" + txtNombre.Text + "'";
            if (con.actualiza("tb_Especialidades", actualizar, "IdEspecialidad=" + txtID.Text))
            {
                MessageBox.Show("Datos actualizados");
                MostrarDatos();
            }
            else
                MessageBox.Show("Error al actualizar...");
        }
    }
}
