﻿using IOC.Bus;
using IOC.Bus.Implement;
using IOC.Bus.Interfaces;
using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        /// <summary>
        /// Register a new user on application
        /// </summary>
        /// <param name="page">Pagina que queremos retornar</param>
        /// <param name="take">Quantidade de registros por página</param>
        /// <remarks>Adds new user to application and grant access</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
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
        public int Post(UsuarioVM usuario)
        {
            return _usuario.Add(usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public bool Put(int id, UsuarioVM usuario)
        {
            _usuario.Update(usuario, id);

            return true;
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
