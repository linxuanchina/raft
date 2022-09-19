using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface ICreationAudited : IHasCreationTime
{
    int? CreatorUserId { get; set; }

    public bool HasCreator => CreatorUserId != null;
}
