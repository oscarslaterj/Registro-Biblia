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
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
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
            return libro;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Libro libro;
            bool paso = false;

            /* if (!Validar())
             return;*/

           libro = Llenaclase();

            if (IDnumericUpDown.Value == 0)
                paso = LibroBLL.Guardar(libro);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un libro que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = LibroBLL.Modificar(libro);

            }
            Limpiar();

            if (paso)

                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puedo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LlenaCampo(Libro libro)
        {
            int LibroId = new Libro().LibroId;
            IDnumericUpDown.Value = LibroId;
            DescripciontextBox.Text = new Libro().Descripcion;
            SiglasTextBox.Text = new Libro().Siglas;
            TiponumericUpDown.Value = new Libro().TipoId;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
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

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            if (LibroBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                ErrorProvider.Equals(IDnumericUpDown, "No se puede eliminar un libro que no existe");
        }


        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
