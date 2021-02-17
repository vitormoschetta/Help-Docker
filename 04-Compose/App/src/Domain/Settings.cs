namespace Domain
{
    public class Settings
    {
        
        public static string ConnectionString()
        {
            return "Server=sqlserver;Database=Backend;user=sa;password=Pass123*";
              
            // server = sqlserver    <-- nome do container de banco de dados
        }        
    }
}