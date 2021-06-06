using IOC.Bus;
using IOC.Bus.Implement;
using IOC.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IOC.Web.Controllers
{
    public class UsuarioController : ApiController
    {

        IUsuarioBus _usuario;
        // GET: api/Usuario

        public UsuarioController(IUsuarioBus usuarioBus)
        {
            _usuario = usuarioBus;
        }

        public UsuarioController()
        {
            
        }

        public IEnumerable<string> Get()
        {
            //var usua = _usuario.GetUsuarios();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
