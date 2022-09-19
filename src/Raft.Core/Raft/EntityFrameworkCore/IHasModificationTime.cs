using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface IHasModificationTime : IEntity
{
    DateTime? LastModificationTime { get; set; }
}
