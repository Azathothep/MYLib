#if MYLIB_UNITASK_SUPPORT

using Cysharp.Threading.Tasks;

namespace MY.Utils.Task
{
    public static class MYUtils
    {
        public static async UniTask DelayAction(System.Action call, int secondDelay)
        {
            await UniTask.Delay(secondDelay * 1000);
            call();
        }
    }
}

#endif