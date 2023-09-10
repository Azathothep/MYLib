using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace MY.Utils
{
	public static class TransformExtensions
	{
		public static void MoveX(this Transform target, float x)
		{
			var pos = target.position;
			pos.x = x;
			target.position = pos;
		}

		public static void MoveY(this Transform target, float y)
		{
			var pos = target.position;
			pos.y = y;
			target.position = pos;
		}

		public static void MoveZ(this Transform target, float z)
		{
			var pos = target.position;
			pos.z = z;
			target.position = pos;
		}

		public static void LocalMoveX(this Transform target, float x)
		{
			var pos = target.localPosition;
			pos.x = x;
			target.position = pos;
		}

		public static void LocalMoveY(this Transform target, float y)
		{
			var pos = target.localPosition;
			pos.y = y;
			target.position = pos;
		}

		public static void LocalMoveZ(this Transform target, float z)
		{
			var pos = target.localPosition;
			pos.z = z;
			target.position = pos;
		}

		public static async UniTask SlowMoveX(this Transform target, float x, float speed, CancellationToken token = default, System.Action onComplete = null) {
			float sign = Mathf.Sign(x - target.position.x);

			while ((target.position.x - x) * sign < 0)
			{
				var newX = target.position.x + Time.deltaTime * sign * speed;
				target.MoveX(newX);
				await UniTask.Yield(cancellationToken: token);
			}

			target.MoveX(x);
			onComplete?.Invoke();
		}

		public static async UniTask SlowMoveY(this Transform target, float y, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			float sign = Mathf.Sign(y - target.position.y);

			while ((target.position.y - y) * sign < 0)
			{
				var newY = target.position.y + Time.deltaTime * sign * speed;
				target.MoveY(newY);
				await UniTask.Yield(cancellationToken: token);
			}

			target.MoveY(y);
			onComplete?.Invoke();
		}

		public static async UniTask SlowMoveZ(this Transform target, float z, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			float sign = Mathf.Sign(z - target.position.z);

			while ((target.position.z - z) * sign < 0)
			{
				var newZ = target.position.z + Time.deltaTime * sign * speed;
				target.MoveZ(newZ);
				await UniTask.Yield(cancellationToken: token);
			}

			target.MoveZ(z);
			onComplete?.Invoke();
		}

		public static UniTask SlowTranslateX(this Transform target, float x, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			return target.SlowMoveX(target.position.x + x, speed, token, onComplete);
		}

		public static UniTask SlowTranslateY(this Transform target, float y, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			return target.SlowMoveY(target.position.y + y, speed, token, onComplete);
		}

		public static UniTask SlowTranslateZ(this Transform target, float z, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			return target.SlowMoveZ(target.position.z + z, speed, token, onComplete);
		}

		public static void RotateZ(this Transform target, float degrees)
		{
			var rotation = target.rotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.z = degrees;
			rotation.eulerAngles = eulerAngles;
			target.rotation = rotation;
		}

		public static void RotateY(this Transform target, float degrees)
		{
			var rotation = target.rotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.y = degrees;
			rotation.eulerAngles = eulerAngles;
			target.rotation = rotation;
		}

		public static void LocalRotateZ(this Transform target, float degrees)
		{
			var rotation = target.localRotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.z = degrees;
			rotation.eulerAngles = eulerAngles;
			target.localRotation = rotation;
		}

		public static void LocalRotateY(this Transform target, float degrees)
		{
			var rotation = target.localRotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.y = degrees;
			rotation.eulerAngles = eulerAngles;
			target.localRotation = rotation;
		}

		/// <summary>
		/// Rotates around Z axis over time, given a degree translation and a spectific speed
		/// </summary>
		public static async UniTask SlowRotateZ(this Transform target, float degrees, float speed, CancellationToken token = default, System.Action onComplete = null)
		{
			float currentDifference = 0;
			float differenceAmount = Mathf.Abs(degrees);
			float sign = Mathf.Sign(degrees);
			float originalRotation = target.rotation.eulerAngles.z;

			while (currentDifference < differenceAmount)
			{
				currentDifference += Time.deltaTime * speed;
				var newRot = originalRotation + currentDifference * sign;
				target.RotateZ(newRot);
				await UniTask.Yield(cancellationToken: token);
			}

			target.RotateZ(originalRotation + degrees);
			onComplete?.Invoke();
		}
	}
}