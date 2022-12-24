using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using treinamento.util.Cliente;
using treinamento.util.DAO;

namespace treinamento.Pages.Clients
{
    public class createModel : PageModel
    {
        private readonly ILogger<createModel> _logger;

        public createModel(ILogger<createModel> logger)
        {
            _logger = logger;
        }

        public ClienteDados clientinfo = new ClienteDados();

        public string errorMessage = "";
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            DAO.Create_Cliente(Request.Form["name"], Request.Form["email"], Request.Form["phone"], Request.Form["adress"]);

            return Redirect("/Clients");
        }
    }

}