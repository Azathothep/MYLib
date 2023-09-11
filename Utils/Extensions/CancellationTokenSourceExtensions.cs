using System.Threading;

namespace MY.Utils
{
    public static class CancellationTokenSourceExtensions
    {
        /// <summary>
        /// Safely resets a <see cref="CancellationTokenSource"/> and returns a new one
        /// </summary>
        /// <param name="cts"></param>
        /// <returns>return a new <see cref="CancellationTokenSource"/></returns>
        public static CancellationTokenSource Reset(this CancellationTokenSource cts)
        {
            cts.Clean();
            return new CancellationTokenSource();
        }

        /// <summary>
        /// Cancels and dispose a <see cref="CancellationTokenSource"/>
        /// </summary>
        /// <param name="cts"></param>
        /// <returns></returns>
        public static void Clean(this CancellationTokenSource cts)
        {
            if (cts.Token.CanBeCanceled)
                cts.Cancel();

            cts.Dispose();
        }
    }
}