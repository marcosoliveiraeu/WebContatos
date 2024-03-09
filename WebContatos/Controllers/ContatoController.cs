using Microsoft.AspNetCore.Mvc;
using WebContatos.Models;
using WebContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;

        }



        public IActionResult Index()
        {
            List<ContatoModel> contatos =  _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar contato. Erro: "+ erro.Message;

                return RedirectToAction("Index");
            }

            

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);

                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";

                    return RedirectToAction("Index");

                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao editar contato. Erro: " + erro.Message;

                return RedirectToAction("Index");
            }

            
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult Apagar(int id)
        {

            try
            {
                bool apag= _contatoRepositorio.Apagar(id);

                if (apag)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar contato."; 
                    return RedirectToAction("Index"); ;
                }

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao apagar contato. Erro: " + erro.Message;
                return RedirectToAction("Index"); ;
            }
           
        }
    }
}
