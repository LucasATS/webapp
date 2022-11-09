using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using sitesite.objetos;
namespace sitesite.DAL
{

    public class cnx_BD
    {
        #region Objetos Estáticos
        private static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        private static IConfigurationRoot configuration = builder.Build();

        private string strconn = configuration.GetConnectionString("DefaultConnection");

        #endregion
        public string insertCliente(Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(@$"
                INSERT INTO dbo.cliente (nome, email, fone, endereco)
                VALUES ('{cliente.Nome}', '{cliente.Email}', '{cliente.Fone}', '{cliente.Endereco}');
            ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return  $"Cadastro realizado com sucesso, { DateTime.Now }";
            }
            catch (System.Exception)
            {
                return $"Desculpa, Ocorreu um erro inesperado";
            }
            finally
            {
                conexao.Close();
            }
        }
        public List<Cliente> listCliente()
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.cliente", conexao);

            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                conexao.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cliente = new Cliente();
                    cliente.Id = int.Parse(reader[0].ToString());
                    cliente.Nome = reader[1].ToString();
                    cliente.Email = reader[2].ToString();
                    cliente.Fone = reader[3].ToString();
                    cliente.Endereco = reader[4].ToString();
                    listaClientes.Add(cliente);
                }
                reader.Close();
                return listaClientes;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Desculpa, Ocorreu um erro inesperado");
                return listaClientes;
            }
            finally
            {
                conexao.Close();
            }
        }
        public string deleteCliente(int id)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.cliente WHERE id = {id};", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return $"Cliente deletado com sucesso, { DateTime.Now }";
            }
            catch (System.Exception)
            {
                return "Desculpa, Ocorreu um erro inesperado";
            }
            finally
            {
                conexao.Close();
            }
        }
        public string editCliente(Cliente cliente)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(@$"
                UPDATE dbo.cliente
                SET nome = '{cliente.Nome}', email = '{cliente.Email}', fone = '{cliente.Fone}', endereco = '{cliente.Endereco}'
                WHERE id = {cliente.Id};
            ", conexao);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return  $"Alterações de cadastro realizadas, { DateTime.Now }";
            }
            catch (System.Exception)
            {
                return "Desculpa, Ocorreu um erro inesperado";
            }
            finally
            {
                conexao.Close();
            }
        }
        public Cliente getCliente(int id)
        {
            SqlConnection conexao = new SqlConnection(strconn);

            SqlCommand cmd = new SqlCommand(@$"
                SELECT * FROM dbo.cliente
                WHERE id = {id};
            ", conexao); 
            try
            {
                conexao.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    Cliente cliente =  new Cliente();
                    cliente.Id = int.Parse(reader[0].ToString());
                    cliente.Nome = reader[1].ToString();
                    cliente.Email = reader[2].ToString();
                    cliente.Fone = reader[3].ToString();
                    cliente.Endereco = reader[4].ToString();
                    reader.Close();
                    return cliente;
                } else
                {
                    reader.Close();
                    return null;
                }
                
            }
            catch (System.Exception)
            {
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}