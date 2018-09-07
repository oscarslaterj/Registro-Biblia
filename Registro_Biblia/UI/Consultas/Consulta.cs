using System;
using Registro_Biblia.Entidades;
using Registro_Biblia.BLL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_Biblia.UI.Consultas
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            var Listado = new List<Libro>();
            LibroBLL persona = new LibroBLL();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        Listado = LibroBLL.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        Listado = LibroBLL.GetList(p => p.LibroId == id);
                        break;
                    case 2:
                        Listado = LibroBLL.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                    case 3:
                        Listado = LibroBLL.GetList(p => p.Siglas.Contains(CriteriotextBox.Text));
                        break;
                    case 4:
                        int TipoID = Convert.ToInt32(CriteriotextBox.Text);
                        Listado = LibroBLL.GetList(p => p.TipoId == TipoID);
                        break;
                    
                }
                Listado = Listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                Listado = LibroBLL.GetList(p => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = Listado;
        }
    }
}
