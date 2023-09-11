using UnityEngine;

namespace MY.Utils
{
    public static class AnimationClipExtensions
    {
        public static void OnTime(this AnimationClip clip, System.Action Action, float time)
        {
            AnimationEvent evt = new AnimationEvent();

            evt.time = time;
            evt.functionName = Action.Method.Name;

            clip.AddEvent(evt);
        }

        public static void OnStart(this AnimationClip clip, System.Action Action)
        {
            clip.OnTime(Action, 0.0f);
        }

        public static void OnComplete(this AnimationClip clip, System.Action Action)
        {
            clip.OnTime(Action, clip.length);
        }
        public static void OnTimeRatio(this AnimationClip clip, System.Action Action, float ratio)
        {
            float time = clip.length * ratio;
            clip.OnTime(Action, time);
        }
    }
}