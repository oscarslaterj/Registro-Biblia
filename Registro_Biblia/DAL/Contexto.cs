using Registro_Biblia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Biblia.DAL
{
   public class Contexto
    {
        public DbSet<Libro> Libro { get; set; }

        public Contexto() : base("Constr") { }

    }
}
