using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Application.Interfaces.Services;
using ProjetoModeloDDD.MVC.Mappers;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IClienteAppService _clienteAppService;

        public ProdutosController(IProdutoAppService produtoAppService, IClienteAppService clienteAppService)
        {
            _produtoAppService = produtoAppService;
            _clienteAppService = clienteAppService;
        }

        // GET: Produtos/Index
        public ActionResult Index()
        {
            var produtos = _produtoAppService.GetAll();
            var produtoViewModels = produtos.Select(p => ProdutoMapper.ToViewModel(p));
            return View(produtoViewModels);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoAppService.GetByID(id);
            if (produto == null)
            {
                return NotFound();
            }

            var produtoViewModel = ProdutoMapper.ToViewModel(produto);
            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(_clienteAppService.GetAll(), "ClienteID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = ProdutoMapper.ToEntity(viewModel);
                _produtoAppService.Add(produto);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(_clienteAppService.GetAll(), "ClienteID", "Nome", viewModel.ClienteID);
            return View(viewModel);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            Console.WriteLine($"Controller: Buscando produto com ID: {id}");

            var produto = _produtoAppService.GetByID(id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return NotFound();
            }

            var produtoViewModel = ProdutoMapper.ToViewModel(produto);
            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o produto existe
                var produto = _produtoAppService.GetByID(produtoViewModel.ProdutoID);
                if (produto == null)
                {
                    ModelState.AddModelError("", "Produto não encontrado.");
                    return View(produtoViewModel);
                }

                // Atualiza os campos do produto
                ProdutoMapper.UpdateEntity(produtoViewModel, produto);

                // Atualiza o produto no banco de dados
                _produtoAppService.Update(produto);

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoAppService.GetByID(id);
            if (produto == null)
            {
                return NotFound();
            }

            var produtoViewModel = ProdutoMapper.ToViewModel(produto);
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoAppService.GetByID(id);
            if (produto == null)
            {
                return NotFound();
            }

            _produtoAppService.Delete(produto);
            return RedirectToAction("Index");
        }
    }
}
