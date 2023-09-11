#if MYLIB_UNITASK_SUPPORT

using Cysharp.Threading.Tasks;

namespace MY.Utils.Task
{
	public static class UniTaskExtensions
	{
		public static void DoNotAwait(this UniTask task) { }
	}
}

#endif