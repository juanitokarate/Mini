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
        FerreteriaEntities BD = new FerreteriaEntities();
       
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
            Dtgrid.DataSource = BD.CLIENTE.ToList();
           
        }

     }
}
