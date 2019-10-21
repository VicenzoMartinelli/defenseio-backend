using System;
using System.Threading.Tasks;

namespace DefenseIO.Infra.Shared.Utils
{
    public class LazyTask<T>
    {
        private readonly Lazy<Task<T>> _task;

        public LazyTask(Func<Task<T>> func)
        {
            _task = new Lazy<Task<T>>(func);
        }

        public static LazyTask<T> Create(Func<Task<T>> func)
        {
            return new LazyTask<T>(func);
        }

        public static LazyTask<T> Create(Func<T> func)
        {
            return new LazyTask<T>(() => Task.FromResult(func.Invoke()));
        }

        public static Lazy<Task<T>> CreateAndGet(Func<Task<T>> func)
        {
            return new LazyTask<T>(func).Get();
        }

        public static Lazy<Task<T>> CreateAndGet(Func<T> func)
        {
            return new LazyTask<T>(() => Task.FromResult(func.Invoke())).Get();
        }

        public Lazy<Task<T>> Get()
        {
            return _task;
        }

        public Task Execute()
        {
            return _task.Value;
        }
        public Task ExecuteIfValueIsNotCreated()
        {
            if(_task.IsValueCreated)
            {
                return Task.CompletedTask;
            }
            else
            {
                return _task.Value;
            }
        }
    }
}
