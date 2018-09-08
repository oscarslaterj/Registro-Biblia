using System;
using Registro_Biblia.BLL;
using Registro_Biblia.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_Biblia.UI.Registros
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            SiglasTextBox.Text = string.Empty;
            TiponumericUpDown.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Libro persona = LibroBLL.Buscar((int)IDnumericUpDown.Value);
            return (persona != null);
        }

        private Libro Llenaclase()
        {
            Libro libro = new Libro();
            libro.LibroId = Convert.ToInt32(IDnumericUpDown.Value);
            libro.Descripcion = string.Empty;
            libro.Siglas = string.Empty;
            libro.TipoId = Convert.ToInt32(TiponumericUpDown.Value);
            libro.Fecha = FechadateTimePicker.Value;
            return libro;
        }


        private void LlenaCampo(Libro libro)
        {
            int LibroId = new Libro().LibroId;
            IDnumericUpDown.Value = LibroId;
            DescripciontextBox.Text = new Libro().Descripcion;
            SiglasTextBox.Text = new Libro().Siglas;
            TiponumericUpDown.Value = new Libro().TipoId;
            FechadateTimePicker.Value = libro.Fecha;
        }

        private bool GuardarValidar()
        {
            bool paso = true;

            if (DescripciontextBox.Text == string.Empty || SiglasTextBox.Text == string.Empty)
            {
                if (DescripciontextBox.Text == string.Empty)
                {
                    SupererrorProvider.SetError(DescripciontextBox, "No puede dejar este campo vacio");
                    DescripciontextBox.Focus();
                }
                if (SiglasTextBox.Text == string.Empty)
                {
                    SupererrorProvider.SetError(SiglasTextBox, "No puede dejar este campo vacio");
                    SiglasTextBox.Focus();
                }

                paso = false;
            }

            return paso;
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            SupererrorProvider.Clear();
            int id;
            Libro libro = new Libro();
            int.TryParse(IDnumericUpDown.Text, out id);

            libro = LibroBLL.Buscar(id);

            if (libro != null)
            {
                MessageBox.Show("Libro Encontrado");
                LlenaCampo(libro);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void Nuevobutton_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click_1(object sender, EventArgs e)
        {
            SupererrorProvider.Clear();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Libro Libro = LibroBLL.Buscar(id);
            Libro libro = Llenaclase();

            if (libro == null)
            {
                if (GuardarValidar())
                {
                    if (LibroBLL.Guardar(libro))
                        MessageBox.Show("Libro guardado");
                    else
                        MessageBox.Show("Libro no guardado");
                }
            }
            else
            {
                if (GuardarValidar())
                {
                    if (LibroBLL.Modificar(libro))
                        MessageBox.Show("Persona modificada");
                    else
                        MessageBox.Show("Persona no modificada");
                }

            }
        }

            private void Eliminarbutton_Click_1(object sender, EventArgs e)
            {
            SupererrorProvider.Clear();
            int id;
                int.TryParse(IDnumericUpDown.Text, out id);

                if (LibroBLL.Eliminar(id))
                    MessageBox.Show("Eliminado");
                else
                    SupererrorProvider.SetError(IDnumericUpDown, "No se puede eliminar un libro que no existe");
            }


        }
    }

