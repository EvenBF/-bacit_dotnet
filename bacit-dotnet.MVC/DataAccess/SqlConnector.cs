using bacit_dotnet.MVC.Entities;
using MySqlConnector;
using bacit_dotnet.MVC.Models.Suggestions;
using bacit_dotnet.MVC.Models.Teams;

namespace bacit_dotnet.MVC.DataAccess
{
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration config;

        public SqlConnector(IConfiguration config)
        {
            this.config = config;
        }

        public IEnumerable<User> GetUsers()
        {

            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var reader = ReadData("Select id, name, email, phone from users;", connection);

            var users = new List<User>();
            while (reader.Read())
            {
                var user = new User();
                user.Id = reader.GetInt32("id");
                user.Name = reader.GetString(1);
                user.Email = reader.GetString(2);
                user.Phone = reader.GetString(3);
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        private MySqlDataReader ReadData(string query, MySqlConnection conn)
        {

            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            var result = command.ExecuteReader();
            Console.WriteLine(result);
            return result;
        }
        private MySqlDataReader ReadSpeData(string query, MySqlConnection conn, int id)
        {

            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", id);
            var result = command.ExecuteReader();
            Console.WriteLine(result);
            return result;
        }
        private void SaveSuggestions(MySqlConnection conn)
        {
            string query = "insert into suggestions (Title, Name, Team, Description) values (\"Tittel\", \"Navn\", 5, \"Dette er en beskrivelse av mitt problem\")";
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        public void SetTeamParam(TeamViewModel model)
        {
            using var connection = new  MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            var query = "insert into team (teamName) values (@teamName)";
            InsertTeam(query, connection, model);
        }

        private void InsertTeam(string query, MySqlConnection conn, TeamViewModel model)
        {
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@teamName", model.teamName);
            command.ExecuteNonQuery();
        }

        public void SetSuggestionsParam(SuggestionViewModel model)
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            var query = "insert into suggestions (Title, TeamId, Description, TimeStamp) values (@Title, @TeamId, @Description, @TimeStamp)"; //Legger til verdiene i tabellen
            var query2 = "update suggestions set userId = (select userId from users where users.firstname=@fName and users.lastname=@lName) where title=@title;"; //oppdaterer userId etter matchende fornavn, etternavn og title
            InsertSuggestions(query, query2, connection, model);
        }

        private void InsertSuggestions(string query, string query2, MySqlConnection conn, SuggestionViewModel model)
        {
            DateTime date1 = DateTime.Now;
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text; 
            command.CommandText = query;
            command.Parameters.AddWithValue("@Title", model.Title); 
            command.Parameters.AddWithValue("@TeamId", model.Team);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@TimeStamp", date1);
            command.ExecuteNonQuery();
            using var command2 = conn.CreateCommand(); //Lager en ny kommando
            command2.CommandType = System.Data.CommandType.Text; //Spesifiserer at kommandoen er typen text
            command2.CommandText = query2; //Spesifiserer at kommandoteksten er lik query2
            command2.Parameters.AddWithValue("@fName", model.fName); //legger til verdien fra fornavnet i modellen til @fName variabelen i query
            command2.Parameters.AddWithValue("@lName", model.lName); //legger til verdien fra etternavnet i modellen til @lName variabelen i query2
            command2.Parameters.AddWithValue("@title", model.Title); //legger til verdien fra fornavnet i modellen til @fName variabelen i query2
            command2.ExecuteNonQuery(); //utfører kommandoen
        }
       
        public  IEnumerable<Suggestion> FetchSug() {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            var Suggestions = new List<Suggestion>();
            var reader = ReadData("select * from  suggestions inner join team on  suggestions.teamId = team.teamId inner join users on suggestions.userId = users.userId", connection); //kobler sammen suggestions, users og team hvor korresponderende id-nøkler er like
            while (reader.Read())
            {
                var user = new Suggestion();
                user.sugId = reader.GetInt32("sugId");
                user.Title = reader.GetString("Title");
                user.fName = reader.GetString("firstName"); //henter fornavn fra tabellen
                user.lName = reader.GetString("lastname"); //henter etternavn fra tabellen
                user.Team = reader.GetString("teamName"); //henter teamnavn fra tabellen
                user.Description = reader.GetString("Description");
                user.TimeStamp = reader.GetDateTime("TimeStamp");
                user.Status = reader.GetString("statusName");
                Suggestions.Add(user);
            }
            connection.Close();
            return Suggestions;
        }

         public  IEnumerable<Suggestion> FetSpeSug(int id) {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var Suggestions = new List<Suggestion>();
            var reader = ReadSpeData("select * from suggestions inner join users on suggestions.userId = users.userId where suggestions.sugId = @id;", connection, id);
            while (reader.Read())
            {
                var user = new Suggestion();
                user.sugId = reader.GetInt32("sugId");
                user.Title = reader.GetString("Title");
                user.fName = reader.GetString("firstname");
                user.lName = reader.GetString("lastname");
                user.teamId = reader.GetInt32("teamId");
                user.Description = reader.GetString("Description");
                Suggestions.Add(user);
            }
            connection.Close();
            return Suggestions;
        }

        public void UpdateValueSetSug(SuggestionViewModel model, int sugId)
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            
            var query = "update suggestions set title=@Title,teamId = @Team,description=@Description, statusName=@Status where sugId =  @sugId;";
            var query2 = "update suggestions set userId = (select userId from users where users.firstname = @fName AND users.lastname = @lName) where suggestions.sugId = @sugId";
            UpdateSuggestions(query, query2, connection, model, sugId);
            
        }

        private void UpdateSuggestions(String query, String query2, MySqlConnection conn, SuggestionViewModel user, int sugId)
        {
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@Title", user.Title); 
            command.Parameters.AddWithValue("@Team", user.Team);
            command.Parameters.AddWithValue("@Description", user.Description);
            command.Parameters.AddWithValue("@Status", user.Status);
            command.Parameters.AddWithValue("@id", sugId);
            command.ExecuteNonQuery();
            using var command2 = conn.CreateCommand();
            command2.CommandType = System.Data.CommandType.Text;
            command2.CommandText = query2;
            command2.Parameters.AddWithValue("@fName", user.fName);
            command2.Parameters.AddWithValue("@lName", user.lName);
            command2.Parameters.AddWithValue("@id", sugId);
            command2.ExecuteNonQuery();

        }

        public void DeleteValueSetSug(SuggestionViewModel model, int sugId)
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
            
            var query = "DELETE FROM suggestions where sugId = @sugId;";
            UpdateSuggestions(query, connection, model, sugId);
            
        }

        private void DeleteSuggestions(String query, MySqlConnection conn, SuggestionViewModel user, int sugId)
        {
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;

            command.Parameters.AddWithValue("@id", sugId);
          
            command.ExecuteNonQuery();
        }

        public void UpdateValueSetGodkjenn(SuggestionViewModel model, int id)
        {
            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();
        
            string query = "update suggestions set statusName = @statusName where sugId =  @id;";
            UpdateGodkjenn(query, connection, model, id);
            
        }
         private void UpdateGodkjenn(String query, MySqlConnection conn, SuggestionViewModel user, int id)
         {
            using var command = conn.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            command.Parameters.AddWithValue("@statusName", user.Status);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
         }
        public IEnumerable<team> GetTeam()
        {

            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var reader = ReadData("SELECT teamId, teamName from team;", connection);

            var users = new List<team>();
            while (reader.Read())
            {
                var team = new team();
                team.teamId = reader.GetInt32("teamId");
                team.teamName = reader.GetString("teamName");
                users.Add(team);
            }
            connection.Close();
            return users;
        }

        public IEnumerable<status> GetStatus()
        {

            using var connection = new MySqlConnection(config.GetConnectionString("MariaDb"));
            connection.Open();

            var reader = ReadData("SELECT statusName from status;", connection);

            var users = new List<status>();
            while (reader.Read())
            {
                var status = new status();
                status.name = reader.GetString("statusName");
                users.Add(status);
            }
            connection.Close();
            return users;
        }
    }
}
