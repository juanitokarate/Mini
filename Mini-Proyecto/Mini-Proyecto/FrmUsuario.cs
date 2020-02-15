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
    public partial class FrmUsuario : Form
    {
        FerreteriaEntities BD = new FerreteriaEntities();
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        void LlenarGrid()
        {
            Dtgrid.DataSource = BD.USUARIO.ToList();
        }
    }
}
