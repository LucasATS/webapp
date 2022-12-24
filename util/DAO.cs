using Microsoft.Data.SqlClient;
using treinamento.util.Cliente;

namespace treinamento.util.DAO
{
    public class DAO
    {
        private static string connectionstring = "Data Source=DESKTOP-R8PHEER\\SQLEXPRESS;Database=teste;Trusted_Connection=True;TrustServerCertificate=True;";

        public static List<ClienteDados> Read_AllClientes()
        {
            List<ClienteDados> listClients = new List<ClienteDados>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "Select * from clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClienteDados clientInfo = new ClienteDados();

                                clientInfo.Id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.adress = reader.GetString(4);
                                clientInfo.create_at = reader.GetDateTime(5).ToString();

                                clientInfo.print("Add:");
                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nEXECUCAO : " + ex.Message.ToString());
            }
            return listClients;
        }

        public static ClienteDados Read_ClienteById(int id)
        {
            ClienteDados clientInfo = new ClienteDados();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "Select * from clients where id = '" + id + "'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientInfo.Id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.adress = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nEXECUCAO : " + ex.Message.ToString());
            }

            return clientInfo;
        }

        public static void Delete_ClienteById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "DELETE FROM clients WHERE id = '" + id + "'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nEXECUCAO : " + ex.Message.ToString());
            }
        }

        public static void Create_Cliente(string name, string email, string phone, string adress)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = $"INSERT INTO clients VALUES ('{name}', '{email}', '{phone}', '{adress}', '{DateTime.Now}')";
                    Console.WriteLine($"Command: {sql}");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nEXECUCAO : " + ex.Message.ToString());
            }
        }

        public static void Update_ClienteById(int id, string name, string email, string phone, string adress)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = $"UPDATE clients SET name = '{name}', email = '{email}', phone = '{phone}', adress = '{adress}' WHERE id = {id}";
                    Console.WriteLine($"SQL: {sql}");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nEXECUCAO : " + ex.Message.ToString());
            }
        }
    }
}