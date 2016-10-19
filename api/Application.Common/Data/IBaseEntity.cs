namespace App.Common.Data
{
    public interface IBaseEntity<TIdType>
    {
        TIdType Id { get; set; }
        System.DateTime CreatedDate { get; set; }
    }
}
