using Loja.ProjetoDDD.Application.Interfaces;
using Loja.ProjetoDDD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Loja.ProjetoDDD.Services.REST.ClienteAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    /*OU (exemplo):
     [EnableCors(origins: "http://mywebclient.azurewebsites.net, http://site tal", headers: "*", methods: "GET,POST")]
         
         */

    public class ClientesController : ApiController
    {

        private readonly IFiliacaoAppService _filiacaoAppService;

        public ClientesController(IFiliacaoAppService filiacaoAppService)
        {
            _filiacaoAppService = filiacaoAppService;
        }

        // GET: api/Clientes
        public IEnumerable<ClienteViewModel> Get()
        {
            return _filiacaoAppService.ObterTodos(); ;
        }

        // GET: api/Clientes/5
        public ClienteViewModel Get(Guid id)
        {
            return _filiacaoAppService.ObterPorId(id);
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
            //_filiacaoAppService.Adicionar();
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
