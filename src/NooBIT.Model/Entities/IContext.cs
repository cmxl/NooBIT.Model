namespace NooBIT.Model.Entities
{
    public interface IContext
    {
        IWriteEntities Write { get; }
        IReadEntities Read { get; }
        IUnitOfWork Store { get; }
    }
}