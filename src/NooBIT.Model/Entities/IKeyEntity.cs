namespace NooBIT.Model.Entities
{
    public interface IKeyEntity : IEntity
    {
        object[] KeyValues { get; }
    }
}