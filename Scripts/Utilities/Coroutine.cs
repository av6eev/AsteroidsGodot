using System.Collections;
using System.Threading.Tasks;

namespace Asteroids.Scripts.Utilities;

public static class Coroutine
{
    public static async Task Run(IEnumerator coroutine)
    {
        while (coroutine.MoveNext())
        {
            switch (coroutine.Current)
            {
                case IEnumerator casted:
                    await Run(casted);
                    break;
                case Waiter castWaiter:
                    await castWaiter.Wait();
                    break;
            }
        }
    }
    
    public abstract class Waiter
    {
        public virtual Task<int> Wait()
        {
            return Task.FromResult(0);
        }
    }
    
    public class WaitForSeconds : Waiter
    {
        private readonly float _timeToWait;
        
        public WaitForSeconds(float seconds) => _timeToWait = seconds;

        public override async Task<int> Wait()
        {
            await Task.Delay((int)(_timeToWait * 1000f));
            return 0;
        }
    }
}