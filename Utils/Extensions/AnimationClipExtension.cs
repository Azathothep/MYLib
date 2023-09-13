using UnityEngine;

namespace MY.Utils
{
    public static class AnimationClipExtensions
    {
        public static void AtTime(this AnimationClip clip, System.Action Action, float time)
        {
            AnimationEvent evt = new AnimationEvent();

            evt.time = time;
            evt.functionName = Action.Method.Name;

            clip.AddEvent(evt);
        }

        public static void OnStart(this AnimationClip clip, System.Action Action)
        {
            clip.AtTime(Action, 0.0f);
        }

        public static void OnComplete(this AnimationClip clip, System.Action Action)
        {
            clip.AtTime(Action, clip.length);
        }
    }
}