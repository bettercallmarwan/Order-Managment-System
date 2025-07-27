namespace Data_Access_Layer.Models.Generic
{
    public class BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey? Id { get; set; }
    }
}
