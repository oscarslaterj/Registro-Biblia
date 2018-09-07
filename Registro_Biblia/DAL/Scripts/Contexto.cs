using System;
using System.Collections.Generic;
using System.Data.Entity;
using Registro_Biblia.Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Biblia.DAL.Scripts
{
    public class Contexto
    {
        public DbSet<Libro> Personas { get; set; }

        public Contexto() : base("Constr") { }
    }
}
