using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace MY.Utils
{
	public static class UniTaskExtensions
	{
		public static void DoNotAwait(this UniTask task) { }
	}
}