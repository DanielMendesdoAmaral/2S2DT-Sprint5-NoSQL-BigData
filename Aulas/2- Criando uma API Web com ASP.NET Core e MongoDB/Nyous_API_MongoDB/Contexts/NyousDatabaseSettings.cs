namespace Nyous_API_MongoDB.Contexts
{
    //Neste context as coisas mudam um pouco, pois ele está pegando as informações do banco no "appsettings.json" na Startup. Mas ainda assim é bem semelhante, por exemplo: Na API com SQL, definíamos DbSets, aqui definimos CollectionNames. Lá, passávamos a connection string, aqui também. O bom é que não precisa de Add-Migration, dotnet ef update database..
    public interface INyousDatabaseSettings
    {
        public string EventosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class NyousDatabaseSettings : INyousDatabaseSettings
    {
        public string EventosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}