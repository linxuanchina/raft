using JetBrains.Annotations;

namespace Raft.EntityFrameworkCore;

[PublicAPI]
public interface IFullAudited : IAudited, IDeletionAudited
{
}
