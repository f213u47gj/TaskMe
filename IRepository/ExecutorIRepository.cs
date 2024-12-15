using TaskMe.Model;

namespace TaskMe.IRepository
{
    public interface ExecutorIRepository
    {
        Task<Executor> GetExecutorById(int id);
        Task<IEnumerable<Executor>> GetAllExecutors(int id);
        Task<Executor> GetExecutorByFullName(string FullName);
    }
}
