using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPendientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pendientes pendientes = new();
        private void Form1_Load(object sender, EventArgs e)
        {
            pendientes.ListaActualizada += Pendientes_ListaActualizada;
        }

        private void Pendientes_ListaActualizada()
        {
            lstPendiente.DataSource = null;
            lstPendiente.DataSource = pendientes.Lista;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pendientes.Agregar(txtPendiente.Text);
            txtPendiente.Clear();
            txtPendiente.Focus();
        }

        private void lstPendiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnBorrar.Enabled = lstPendiente.SelectedItem != null;
            //btnArriba.Enabled =
            //    lstPendiente.SelectedItem != null;
            //btnAbajo.Enabled = lstPendiente.SelectedItem != null;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            pendientes.Borrar(lstPendiente.SelectedItem as string);
        }

        private void btnArriba_Click(object sender, EventArgs e)
        {
            try
            {
                String pendiente = lstPendiente.SelectedItem as string;
                pendientes.Subir(pendiente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbajo_Click(object sender, EventArgs e)
        {
            pendientes.Bajar(lstPendiente.SelectedItem as string);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Auxiliar.Guardar(pendientes, "pendientes.txt");
        }
    }
}
