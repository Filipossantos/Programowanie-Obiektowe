using Npgsql;

namespace Stock_Information_System.App_Data.Users
{
    public class db_connection
    {
        private string connectionString;

        public db_connection()
        {
            connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
        }

        public bool AuthenticateUser(string username, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT password FROM user_data WHERE login = @username";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedPassword = reader.GetString(0);

                           
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