#if MYLIB_UNITASK_SUPPORT

using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MY.Utils.Task
{
    public static class UniTaskGameObjectExtensions
    {
		/// <summary>
		/// Activate or deactivate a GameObject after a specified delay
		/// </summary>
		/// <param name="go">reference <see cref="GameObject"/></param>
		/// <param name="active">activate or deactivate</param>
		/// <param name="delay">delay in seconds</param>
		/// <param name="token">the <see cref="CancellationToken"/></param>
		public static async void SetActiveDelay(this GameObject go, bool active, float delay, CancellationToken token = default)
		{
			await UniTask.Delay((int)(delay * 1000), cancellationToken: token);
			go.SetActive(active);
		}
	}
}

#endif