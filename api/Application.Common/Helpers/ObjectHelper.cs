namespace App.Common.Helpers
{
    public class ObjectHelper
    {
        public static TEntity Convert<TEntity>(object obj)
        {
            return AutoMapper.Mapper.Map<TEntity>(obj);
        }
    }
}
