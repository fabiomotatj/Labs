using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMVC.Ent
{
    [Table("usuario")]
    public class UsuarioEnt
    {

        [Key,Column("email")]
        public string email { get; set; }

       [Column("nome")]
        public string nome { get; set; }

        [Column("telefone")]
        public string telefone { get; set; }
    }
}
