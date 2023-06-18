using Npgsql;

namespace Stock_Information_System.App_Data.Users
{
    public class DbConnection
    {
        private string connectionString;

        public DbConnection()
        {
            connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
        }

        public bool AuthenticateUser(string username, string password, out bool isAdmin)
        {
            isAdmin = false;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT password,is_admin FROM user_data WHERE login = @username";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedPassword = reader.GetString(0);
                            isAdmin = reader.GetBoolean(1);
                           
                            if (storedPassword == password)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false; 
        }
        
    }
}