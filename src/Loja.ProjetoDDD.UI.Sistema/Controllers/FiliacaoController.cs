using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loja.ProjetoDDD.Application.Interfaces;
using Loja.ProjetoDDD.Application.Services;
using Loja.ProjetoDDD.Application.ViewModels;
using Loja.ProjetoDDD.Infra.CrossCutting.MvcFilters;
using Loja.ProjetoDDD.UI.Sistema.Models;

namespace Loja.ProjetoDDD.UI.Sistema.Controllers
{
    /*ModuloCliente:
  CL - listar
  CI - criar
  CE - editar
  CD - ver detalhes
  CX- deletar
  */
    /*com essa tag antes da controller estou proibiindo que qualquer usuário não logado
    tenha acesso a essa controller*/
    [Authorize]
    [RoutePrefix("administrativo-filiacao")]
    public class FiliacaoController : Controller
    {

        private readonly IFiliacaoAppService _filiacaoAppService;

        public FiliacaoController(IFiliacaoAppService filiacaoAppService)
        {
            _filiacaoAppService = filiacaoAppService;
        }

        /*abaixo, eu que crio as modulos, vou criar o seguinte:
         ModuloCliente - CL, CI, CE, CD, CX. Cl - Cliente lista... LD - cliente deletar etc*/
        [Route("listar-clientes")]
        [ClaimsAuthorize("ModuloCliente", "CL")]
        public ActionResult Index()
        {
            return View(_filiacaoAppService.ObterTodos());
        }

        //Abaixo: que a rota mostre o id e esse id é um guid...
        [Route("{id:guid}/detalhe-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CD")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _filiacaoAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("novo-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CI")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CI")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteReturn = _filiacaoAppService.Adicionar(clienteEnderecoViewModel).ClienteViewModel;
                if (!clienteReturn.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteReturn.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(clienteEnderecoViewModel);

                }


                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }


        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CE")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _filiacaoAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {

                _filiacaoAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }


        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _filiacaoAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }


        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _filiacaoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _filiacaoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
