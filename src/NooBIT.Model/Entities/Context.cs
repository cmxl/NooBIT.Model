namespace NooBIT.Model.Entities
{
    public class Context : IContext
    {
        public Context(IWriteEntities writeEntities, IReadEntities readEntities, IUnitOfWork unitOfWork)
        {
            Write = writeEntities;
            Read = readEntities;
            Store = unitOfWork;
        }

        public IWriteEntities Write { get; }
        public IReadEntities Read { get; }
        public IUnitOfWork Store { get; }
    }
}