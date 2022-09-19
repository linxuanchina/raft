using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface IHasCreationTime : IEntity
{
    DateTime CreationTime { get; set; }
}
