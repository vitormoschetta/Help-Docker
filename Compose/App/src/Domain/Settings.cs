namespace Domain
{
    public class Settings
    {
        // server = sqlserver    <-- nome do container de banco de dados
        public static string ConnectionString()
        {
            return "Server=sqlserver;Database=Backend;user=sa;password=Pass123*";  
        }        
    }
}