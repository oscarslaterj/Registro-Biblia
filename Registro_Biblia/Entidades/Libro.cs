using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Biblia.Entidades
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }
        public string Descripcion { get; set; }
        public string Siglas { get; set; }
        public int TipoId { get; set; }
        public DateTime Fecha  { get; set; }


        public Libro()
        {
            LibroId = 0;
            Descripcion = string.Empty;
            Siglas = string.Empty;
            Siglas = string.Empty;
            TipoId = 0;
            Fecha = DateTime.Now;
        }
    }
}
