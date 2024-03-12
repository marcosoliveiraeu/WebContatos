using Microsoft.AspNetCore.Mvc;
using WebContatos.Models;
using WebContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebContatos.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }



        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar usuario. Erro: " + erro.Message;

                return RedirectToAction("Index");
            }

            

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);

                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";

                    return RedirectToAction("Index");

                }

                return View("Editar", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao editar usuário. Erro: " + erro.Message;

                return RedirectToAction("Index");
            }

            
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {

            try
            {
                bool apag= _usuarioRepositorio.Apagar(id);

                if (apag)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar usuário."; 
                    return RedirectToAction("Index"); ;
                }

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao apagar usuário. Erro: " + erro.Message;
                return RedirectToAction("Index"); ;
            }
           
        }
    }
}
