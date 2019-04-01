using AutoMapper;
using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var clientesViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.GetAll());
            return View(clientesViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Especiais()
        {
            var clientesViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.ObterClientesEspeciais());
            return View(clientesViewModel);
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteAppService.Add(clienteDomain);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteAppService.Update(clienteDomain);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmaded(int id)
        {
            var cliente = _clienteAppService.GetById(id);
            _clienteAppService.Remove(cliente);
            return RedirectToAction("Index");
        }
    }
}
