using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace treinamento.util.Cliente
{
    public class ClienteDados
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string adress { get; set; }
        public string create_at { get; set; }

        public void print(string msg = ""){
            Console.WriteLine(msg + $" {Id} {name} {email} {phone} {adress} {create_at}");
        }
    }
}