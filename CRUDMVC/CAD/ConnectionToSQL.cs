using System.Data.SqlClient;

namespace CAD
{
    //Clase abstracta
    public abstract class ConnectionToSQL
    {
        private readonly string _connectionString;
        public ConnectionToSQL()
        {
            string servidor = "DESKTOP-69J6VS7";
            string db = "Nexus";

            _connectionString = "Server=" + servidor + "; DataBase=" + db + "; Integrated security= true";
        }

        //Metodo protegido retorna la conexion
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
