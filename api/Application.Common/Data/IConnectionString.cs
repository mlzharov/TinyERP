namespace App.Common.Data
{
    public interface IConnectionString
    {
        string Name { get; set; }
        string Database { get; set; }
        string Server { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        DatabaseType DbType { get; set; }
    }
}
