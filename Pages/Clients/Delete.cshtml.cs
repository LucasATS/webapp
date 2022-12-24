using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using treinamento.util.DAO;
using treinamento.util.Cliente;

namespace treinamento.Pages.Clients
{

    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        public ClienteDados cliente;

        public DeleteModel(ILogger<DeleteModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
           cliente = DAO.Read_ClienteById(int.Parse(Request.Query["id"]));
           cliente.print("Deletar:");
        }
        public IActionResult OnPost()
        {
            DAO.Delete_ClienteById(int.Parse(Request.Query["id"]));

            return Redirect("/Clients");
        }
    }
}