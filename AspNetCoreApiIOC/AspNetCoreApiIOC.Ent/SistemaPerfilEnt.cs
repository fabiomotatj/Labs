using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AspNetCoreApiIOC.Ent
{
    [Table("tb_sistemaperfil")]
    public class SistemaPerfilEnt
    {
        [Key, Column("sistemaperfil_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("perfil_id")]
        public int IdPerfil { get; set; }

        [Column("sistema_id")]
        public int IdSistema { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual PerfilEnt Perfil { get; set;}

        [ForeignKey("IdSistema")]
        public virtual SistemaEnt Sistema { get; set; }
    }
}
