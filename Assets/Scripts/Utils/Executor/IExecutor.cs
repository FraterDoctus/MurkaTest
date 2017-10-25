using System.Collections;

namespace Utils.Executor
{
    public interface IExecutor
    {
        void Execute(IEnumerator coroutine);
    }
}