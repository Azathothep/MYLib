using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MY.States
{
	public class StaterFunc
	{
		public enum Time
		{
			Enter,
			Step,
			AtStep,
			OnTrigger,
			Exit
		}

		private Time m_Time;
		public Time time => m_Time;

		public delegate void VFunc();

		public VFunc vFunc;

		public float f0;
		public string s0;

		public bool called;

		private StaterFunc(StaterFunc.Time _time, StaterFunc.VFunc _vFunc, float _f0 = 0.0f)
		{
			this.m_Time = _time;
			this.vFunc = _vFunc;
			this.f0 = _f0;
		}

		private StaterFunc(StaterFunc.Time _time, StaterFunc.VFunc _func, string _s0)
		{
			this.m_Time = _time;
			this.vFunc= _func;
			this.s0 = _s0;
		}

		public static StaterFunc ENTER(StaterFunc.VFunc _func)
		{
			return new StaterFunc(StaterFunc.Time.Enter, _func);
		}

		public static StaterFunc AT_STEP(float time, StaterFunc.VFunc _func)
		{
			return new StaterFunc(StaterFunc.Time.AtStep, _func, time);
		}

		public static StaterFunc STEP(StaterFunc.VFunc _func)
		{
			return new StaterFunc(StaterFunc.Time.Step, _func);
		}

		public static StaterFunc ON_TRIGGER(string triggerID, StaterFunc.VFunc _func)
		{
			return new StaterFunc(StaterFunc.Time.OnTrigger, _func, triggerID);
		}

		public static StaterFunc EXIT(StaterFunc.VFunc _func)
		{
			return new StaterFunc(StaterFunc.Time.Exit, _func);
		}
	}
}
