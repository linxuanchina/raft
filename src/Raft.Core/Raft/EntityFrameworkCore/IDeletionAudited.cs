using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface IDeletionAudited : ISoftDelete
{
    int? DeleterUserId { get; set; }

    public bool HasDeleter => DeleterUserId != null;
}
