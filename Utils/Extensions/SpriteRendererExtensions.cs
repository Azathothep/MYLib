using UnityEngine;

namespace MY.Utils
{
	public static class SpriteRendererExtensions
	{
		/// <summary>
		/// Sets a <see cref="SpriteRenderer"/> alpha
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="alpha"></param>
		public static void SetAlpha(this SpriteRenderer rdr, float alpha)
		{
			Color c = rdr.color;
			c.a = alpha;
			rdr.color = c;
		}
	}
}