namespace App.Common.Mail
{
    public interface IMailService
    {
        void Send<TEntity>(TEntity emailConent) where TEntity : IEmailContent;
    }
}
