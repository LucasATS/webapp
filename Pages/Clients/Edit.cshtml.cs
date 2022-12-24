using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using treinamento.util.Cliente;
using treinamento.util.DAO;

namespace treinamento.Pages.Clients
{

    public class Edit : PageModel
    {
        public ClienteDados clientInfo = new ClienteDados();

        public string errorMessage = "";

        public void OnGet()
        {
            clientInfo = DAO.Read_ClienteById(int.Parse(Request.Query["id"]));
            clientInfo.print("Update:");
        }

        public IActionResult OnPost()
        {
            DAO.Update_ClienteById(int.Parse(Request.Query["id"]), Request.Form["name"], Request.Form["email"], Request.Form["phone"], Request.Form["adress"]);

            return Redirect("/Clients");
        }
    }
}