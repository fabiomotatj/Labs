using IOC.Bus;
using IOC.Bus.Implement;
using IOC.Bus.Interfaces;
using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

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

        [HttpGet]
        public IEnumerable<UsuarioVM> GetPaged(int page, int take)
        {
            return _usuario.GetPaged(page, take);
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        [HttpPost]
        public void Post(UsuarioVM value)
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
