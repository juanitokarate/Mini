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
    public partial class FrmCategoria : Form
    {
        FerreteriaEntities BD = new FerreteriaEntities();
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        void LlenarGrid()
        {
            Dtgrid.DataSource = BD.CATEGORIA.ToList();
        }
    }
}
