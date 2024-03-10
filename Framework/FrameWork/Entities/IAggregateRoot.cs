using Framework.Event;

namespace Framework.Entities
{
    public interface IAggregateRoot
    {
        void ClearEvents();
        IEnumerable<IDomainEvent> GetEvents();
    }
}