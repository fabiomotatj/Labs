using AspNetCoreApiIOC.Bus;
using AspNetCoreApiIOC.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiIOC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioBus _usuarioBus;
        public UsuarioController(UsuarioBus usuarioBus)
        {
            _usuarioBus = usuarioBus;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioVM>> ListaUsuario()
        {
            return await _usuarioBus.ListaUsuarios();
        }

        [HttpPost]
        public async Task<UsuarioVM> Add([FromBody] UsuarioVM usuario)
        {
            return await _usuarioBus.Add(usuario);
        }

        [HttpPost]
        [Route("AddSistemaPerfil")]
        public async Task<SistemaPerfilVM> AddSistemaPerfil([FromBody] SistemaPerfilVM sistemaPerfil)
        {
            return await _usuarioBus.AddSistemaPerfil(sistemaPerfil);
        }
    }
}
