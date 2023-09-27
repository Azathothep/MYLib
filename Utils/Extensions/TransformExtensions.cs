using UnityEngine;

namespace MY.Utils
{
	public static class TransformExtensions
	{
		public static void MYMoveX(this Transform target, float x)
		{
			var pos = target.position;
			pos.x = x;
			target.position = pos;
		}

		public static void MYMoveY(this Transform target, float y)
		{
			var pos = target.position;
			pos.y = y;
			target.position = pos;
		}

		public static void MYMoveZ(this Transform target, float z)
		{
			var pos = target.position;
			pos.z = z;
			target.position = pos;
		}

		public static void MYLocalMoveX(this Transform target, float x)
		{
			var pos = target.localPosition;
			pos.x = x;
			target.localPosition = pos;
		}

		public static void MYLocalMoveY(this Transform target, float y)
		{
			var pos = target.localPosition;
			pos.y = y;
			target.localPosition = pos;
		}

		public static void MYLocalMoveZ(this Transform target, float z)
		{
			var pos = target.localPosition;
			pos.z = z;
			target.localPosition = pos;
		}

		public static void MYRotateZ(this Transform target, float degrees)
		{
			var rotation = target.rotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.z = degrees;
			rotation.eulerAngles = eulerAngles;
			target.rotation = rotation;
		}

		public static void MYRotateY(this Transform target, float degrees)
		{
			var rotation = target.rotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.y = degrees;
			rotation.eulerAngles = eulerAngles;
			target.rotation = rotation;
		}

		public static void MYRotate(this Transform target, Vector3 degrees)
		{
			var rotation = target.rotation;
			rotation.eulerAngles = degrees;
			target.rotation = rotation;
		}

		public static void MYSetRotation(this Transform target, Vector3 angles)
        {
			var rotation = target.rotation;
			var eulerAngles = angles;
			rotation.eulerAngles = eulerAngles;
			target.rotation = rotation;
		}

		public static void MYLocalRotateZ(this Transform target, float degrees)
		{
			var rotation = target.localRotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.z = degrees;
			rotation.eulerAngles = eulerAngles;
			target.localRotation = rotation;
		}

		public static void MYLocalRotateY(this Transform target, float degrees)
		{
			var rotation = target.localRotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.y = degrees;
			rotation.eulerAngles = eulerAngles;
			target.localRotation = rotation;
		}

		public static void MYLocalScaleX(this Transform target, float scaleX)
		{
			var scale = target.localScale;
			scale.x = scaleX;
			target.localScale = scale;
		}
	}
}