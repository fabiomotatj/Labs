using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApiIOC.VM
{
    public class SistemaPerfilVM
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int IdSistema { get; set; }
        public virtual PerfilVM Perfil { get; set; }
        public virtual SistemaVM Sistema { get; set; }
    }
}
