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
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;
        public ProdutosController(IProdutoAppService ProdutoAppService, IClienteAppService clienteAppService)
        {
            _produtoAppService = ProdutoAppService;
            _clienteAppService = clienteAppService;
        }
        // GET: Produtos
        public ActionResult Index()
        {
            var ProdutosViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoAppService.GetAll());
            return View(ProdutosViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var Produto = _produtoAppService.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);
            return View(ProdutoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel ProdutoViewModel)
        {
            if (ModelState.IsValid)
            {
                var ProdutoDomain = Mapper.Map<ProdutoViewModel, Produto>(ProdutoViewModel);
                _produtoAppService.Add(ProdutoDomain);
                return RedirectToAction("Index");
            }
            return View(ProdutoViewModel);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome", id);
            var Produto = _produtoAppService.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);
            return View(ProdutoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel ProdutoViewModel)
        {
            if (ModelState.IsValid)
            {
                var ProdutoDomain = Mapper.Map<ProdutoViewModel, Produto>(ProdutoViewModel);
                _produtoAppService.Update(ProdutoDomain);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteAppService.GetAll(), "ClienteId", "Nome", ProdutoViewModel.ClienteId);
            return View(ProdutoViewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var Produto = _produtoAppService.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);
            return View(ProdutoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmaded(int id)
        {
            var Produto = _produtoAppService.GetById(id);
            _produtoAppService.Remove(Produto);
            return RedirectToAction("Index");
        }
    }
}
