namespace Raft;

public interface IInstanceFactory<out T> where T : class
{
    T CreateInstance();
}
