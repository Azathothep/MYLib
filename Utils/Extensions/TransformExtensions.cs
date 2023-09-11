using UnityEngine;

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
	}
}