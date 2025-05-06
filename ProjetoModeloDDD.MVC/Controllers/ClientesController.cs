using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.MVC.Mappers;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            var clientes = _clienteRepository.GetAll();

            // mapeia a lista de entidades para lista de viewmodels
            var clienteViewModels = clientes.Select(c => ClienteMapper.ToViewModel(c));

            return View(clienteViewModels);
        }




        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = ClienteMapper.ToEntity(viewModel);
                _clienteRepository.Add(clienteDomain);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(ClienteViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var clienteDomain = ClienteMapper.ToEntity(viewModel); // Mapeia pra entidade de domínio!
        //        _clienteRepository.Add(clienteDomain);

        //        return RedirectToAction("Index");
        //    }
        //    return View(viewModel);
        //}

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
