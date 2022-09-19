using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface ISoftDelete : IEntity
{
    bool IsDeleted { get; set; }

    DateTime? DeletionTime { get; set; }
}
