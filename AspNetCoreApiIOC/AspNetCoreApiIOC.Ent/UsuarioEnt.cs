using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreApiIOC.Ent
{
    [Table("tb_usuario")]
    public class UsuarioEnt
    {
        [Key, Column("usuario_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("login")]
        public string Login { get; set; }
    }
}
