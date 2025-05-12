using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interfaces.Services;
using ProjetoModeloDDD.MVC.Mappers;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public ActionResult Index()
        {
            var clientes = _clienteAppService.GetAll();

            // mapeia a lista de entidades para lista de viewmodels
            var clienteViewModels = clientes.Select(c => ClienteMapper.ToViewModel(c));

            return View(clienteViewModels);
        }

        public ActionResult getClienteEspecial()
        {
            var clientesEspeciais = _clienteAppService.ObterClientesEspeciais();

            var clientesEspeciaisViewModel = clientesEspeciais.Select(c => ClienteMapper.ToViewModel(c));

            return View(clientesEspeciaisViewModel);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteAppService.GetByID(id);

            var clienteViewModel = ClienteMapper.ToViewModel(cliente);

            return View(clienteViewModel);
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
                _clienteAppService.Add(clienteDomain);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: ClientesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var cliente = _clienteAppService.GetByID(id);

        //    var clienteViewModel = ClienteMapper.ToViewModel(cliente);

        //    return View(clienteViewModel);

        //}

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            Console.WriteLine($"Controller: Buscando cliente com ID: {id}");

            var cliente = _clienteAppService.GetByID(id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return NotFound();
            }

            var clienteViewModel = ClienteMapper.ToViewModel(cliente);
            return View(clienteViewModel);
        }


        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                
                // Verifica se o cliente existe
                var cliente = _clienteAppService.GetByID(clienteViewModel.ClienteID);
                if (cliente == null)
                {
                    ModelState.AddModelError("", "Cliente não encontrado.");
                    return View(clienteViewModel);
                }

                // Atualiza os campos do cliente
                ClienteMapper.UpdateEntity(clienteViewModel, cliente);

                // Atualiza o cliente no banco de dados
                _clienteAppService.Update(cliente);

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }
        


        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteAppService.GetByID(id);
            var clienteViewModel = ClienteMapper.ToViewModel(cliente);

            _clienteAppService.Delete(cliente);

            return RedirectToAction("Index");
        }

        // POST: ClientesController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteAppService.GetByID(id);
            _clienteAppService.Delete(cliente);

            return RedirectToAction("Index");
        }
    }
}
