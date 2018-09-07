using System;
using Registro_Biblia.UI.Consultas;
using Registro_Biblia.UI.Registros;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_Biblia
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.MdiParent = this;
            registro.Show();
            
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            registroToolStripMenuItem1_Click(sender, e);
        }
    }
}
