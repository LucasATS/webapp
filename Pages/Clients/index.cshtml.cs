using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Web;
using treinamento.util.Cliente;
using treinamento.util.DAO;

namespace treinamento.Pages.Clients
{

    public class IntexModel : PageModel
    {
        // public void OnTest()
        // {
        //     // var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
        //     Request.QueryString.ToString().Split('=')[1]
        // }

        public List<ClienteDados> listClients = new List<ClienteDados>();
        public void OnGet()
        {
            listClients = DAO.Read_AllClientes();
        }
    }
}