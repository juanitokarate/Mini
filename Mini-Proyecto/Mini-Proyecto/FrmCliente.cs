using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Proyecto
{
    public partial class FrmCliente : Form
    {
        FerreteriaEntities1 BD2 = new FerreteriaEntities1();
       
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

         void LlenarGrid()
        {
            Dtgrid.DataSource = BD2.CLIENTE.ToList();
           
        }

        private void Dtgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        void Limpiar()
        {

            txtCve.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtDireccion.Text = "";
            txtRFC.Text = "";
            dtFechaNac.Value = DateTime.Today.Date;
            txtNombre.Focus();
        }
        CLIENTE GetCLIENTE(int Clave)
        {
            CLIENTE cliente = BD2.CLIENTE.Find(Clave);
            return cliente;
        }
        void CargarCliente(CLIENTE cliente)
        {
            txtCve.Text = cliente.Cli_Clave.ToString();
            txtNombre.Text = cliente.Cli_Nombre.ToUpper();
            txtDireccion.Text = cliente.Cli_Direccion.ToUpper();
            txtRFC.Text = cliente.Cli_Rfc.ToUpper();
            txtCategoria.Text = cliente.Cli_Categoria.ToString();
               
           dtFechaNac.Text = cliente.Cli_Fecha_Nac.ToString();
            txtCve.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          if(txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Favor de llenar el nombre");
                txtNombre.Focus();
                return;
            }
          if(txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Favor de llenar la direccion");
                txtDireccion.Focus();
                return;
            }
          if(txtRFC.Text.Trim() == "")
            {
                MessageBox.Show("Favor de llenar su RFC");
                txtRFC.Focus();
                return;
            }
            if (txtCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Favor de ingresar la categoria del cliente");
                return;
            }
            CLIENTE cliente;
            if (!txtCve.Enabled)
            {
                cliente = new CLIENTE();
                cliente.Cli_Nombre = txtNombre.Text.ToUpper();
                cliente.Cli_Direccion = txtDireccion.Text.ToUpper();
                cliente.Cli_Fecha_Nac = dtFechaNac.Value.Date;
                cliente.Cli_Rfc = txtRFC.Text.ToUpper();
                cliente.Cli_Categoria =Convert.ToInt32(txtCategoria.Text.ToUpper());
                BD2.CLIENTE.Add(cliente);
            }
            else
            {
                cliente = GetCLIENTE(Convert.ToInt32( txtCve.Text));
                if (cliente != null)
                {
                    cliente.Cli_Nombre = txtNombre.Text.ToUpper();
                    cliente.Cli_Direccion = txtDireccion.Text.ToUpper();
                    cliente.Cli_Fecha_Nac = dtFechaNac.Value.Date;
                    cliente.Cli_Rfc = txtRFC.Text.ToUpper();
                    cliente.Cli_Categoria = Convert.ToInt32(txtCategoria.Text.ToUpper());

                }
                
            }
            BD2.SaveChanges();
            MessageBox.Show("Se guardo exitosamente el cliente");
            LlenarGrid();
        }

        private void Dtgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                CargarCliente(GetCLIENTE(Convert.ToInt32( Dtgrid[0, e.RowIndex].Value.ToString())));
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!txtCve.Enabled)
            {
                if (MessageBox.Show("Desea eliminar el clientes", "Eliminar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLIENTE cli = GetCLIENTE(Convert.ToInt32( txtCve.Text));
                    BD2.CLIENTE.Remove(cli);
                    BD2.SaveChanges();
                    MessageBox.Show("Cliente: " + txtNombre.Text + "eliminado exitosamente!");
                    LlenarGrid();
                    Limpiar();

                }
            }
        }
    }
}
