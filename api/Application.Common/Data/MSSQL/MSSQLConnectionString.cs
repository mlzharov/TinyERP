namespace App.Common.Data.MSSQL
{
    public class MSSQLConnectionString : ConnectionString
    {
        public MSSQLConnectionString(string connectionName = "")
            : base(DatabaseType.MSSQL, connectionName)
        {
            this.Port = 1433;
        }
        public override string ToString()
        {
            string connection = "Data Source={0};Initial Catalog={2};User ID={3};Password={4}";
            return string.Format(connection, this.Server, this.Port < 0 ? "" : "," + this.Port, this.Database, this.UserName, this.Password);
        }
    }
}
