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
            string ret = retContStr("hhartr");

            return await _usuarioBus.ListaUsuarios();
        }

        private string retContStr(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for(int i=0; i< str.Length; i++)
            {
                if (!dic.ContainsKey(str[i]))
                    dic.Add(str[i], 1);
                else
                    dic[str[i]] += dic[str[i]]; 
            }

            string aux = "";

            for (int i = 0; i < dic.Count; i++)
            {
                aux = aux + dic.ElementAt(i).Key + " - " + dic.ElementAt(i).Value + ",";
            }
                
            return aux.Substring(0,aux.Length -1 );
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
