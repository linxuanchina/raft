using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface IAudited : ICreationAudited, IModificationAudited
{
}
