namespace Domain
{
    public class Settings
    {
        // server = sqlserver    <-- nome do container de banco de dados
        public static string ConnectionString()
        {
            return "Datasource=../Backend.db";  
        }        
    }
}