using Microsoft.AspNetCore.Mvc;
using WebContatos.Models;
using WebContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebContatos.Controllers
{
    public class LoginController : Controller
    {


        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]  
        public IActionResult Entrar(LoginModel loginmodel)
        {

            try
            {
                if(ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorlogin(loginmodel.Login);

                    if (usuario != null)
                    {

                        if (loginmodel.Senha == usuario.Senha)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "Senha inválida.";

                    }
                    else 
                    { 
                        TempData["MensagemErro"] = "Usuário inválido(s)."; 
                    }               

                }

                return View("Index");
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Erro ao efetuar login. Erro: " + erro.Message;
                return View("Index");
            }


            
        }




    }
}
