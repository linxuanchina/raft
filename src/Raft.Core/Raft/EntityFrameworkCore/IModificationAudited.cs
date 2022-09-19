using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface IModificationAudited : IHasModificationTime
{
    int? LastModifierUserId { get; set; }

    public bool HasModifier => LastModifierUserId != null;
}
