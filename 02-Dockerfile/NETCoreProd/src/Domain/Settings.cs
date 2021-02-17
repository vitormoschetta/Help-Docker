namespace Domain
{
    public class Settings
    {
        public static string ConnectionString()
        {
            return "Server=localhost,1433;Database=Backend;user=sa;password=Pass123*";  
        }
    }
}