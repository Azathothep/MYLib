#if MYLIB_UNITASK_SUPPORT

using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace MY.Utils.Task
{
    public static class UniTaskSpriteRendererExtensions
    {
		/// <summary>
		/// Fade a <see cref="SpriteRenderer"/> at a certain speed
		/// </summary>
		/// <param name="rdr">reference <see cref="SpriteRenderer"/></param>
		/// <param name="targetAlpha">target alpha (0-1)</param>
		/// <param name="timing">fade speed (alpha per seconds) or delay (in seconds)</param>
		/// <param name="options">the <see cref="MYTweenOptions"/></param>
		/// <param name="token">a <see cref="CancellationToken"/></param>
		/// <param name="onComplete"><see cref="System.Action"/> called fade on complete</param>
		/// <returns></returns>
		public static async UniTask MYFade(this SpriteRenderer rdr, float targetAlpha, float timing, MYTweenOptions options = MYTweenOptions.BySpeed, CancellationToken token = default, System.Action onComplete = null)
		{
			float speed = timing;
			if (options == MYTweenOptions.ByDelay)
				speed = timing == 0 ? int.MaxValue :
										Mathf.Abs(rdr.color.a - targetAlpha) / timing;

			await rdr._MYFadeBySpeed(targetAlpha, speed, token, onComplete);
		}

		private static async UniTask _MYFadeBySpeed(this SpriteRenderer rdr, float targetAlpha, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			float originalAlpha = rdr.color.a;
			float accumulator = 0.0f;

			float difference = targetAlpha - originalAlpha;
			float differenceAbs = Mathf.Abs(difference);

			float sign = Mathf.Sign(difference);

			while (accumulator < differenceAbs)
			{
				accumulator += Time.deltaTime * speed;
				rdr.SetAlpha(originalAlpha + accumulator * sign);
				await UniTask.Yield(cancellationToken: token);
			}

			rdr.SetAlpha(targetAlpha);
			onComplete?.Invoke();
		}
	}
}

#endif