using System;
using System.Collections.Generic;
using UnityEngine;

namespace MY.States
{
	public class StaterState<StateID> where StateID : struct, IConvertible
	{
		public readonly StateID State;

		private bool m_HasAfterState = false;
		public bool HasAfterState => m_HasAfterState;

		private StateID m_AfterState;
		public StateID AfterState => m_AfterState;

		private bool m_NeedsStep = false;
		public bool NeedsStep => m_NeedsStep;

		private float m_StepTime;
		public float StepTime => m_StepTime;

		private float m_StepDuration;
		public float StepDuration => m_StepDuration;

		private List<StaterFunc> m_Funcs = new List<StaterFunc>();

		public StaterState(StateID _state)
		{
			this.State = _state;
		}

		public StaterState<StateID> AddFunc(StaterFunc _func)
		{
			this.m_Funcs.Add(_func);
			this.m_NeedsStep = (_func.time == StaterFunc.Time.Step || _func.time == StaterFunc.Time.AtStep);
			return this;
		}

		public StaterState<StateID> SetDuration(float _stepDuration)
		{
			this.m_StepDuration = _stepDuration;
			this.m_NeedsStep = (this.StepDuration > 0);
			return this;
		}

		public StaterState<StateID> SetDuration(float _stepDuration, StateID _afterState)
		{
			this.m_StepDuration = _stepDuration;
			this.m_AfterState = _afterState;
			this.m_HasAfterState = true;
			this.m_NeedsStep = (this.m_StepDuration > 0.0f);
			return this;
		}

		public void Enter()
		{
			foreach (StaterFunc staterFunc in this.m_Funcs)
			{
				if (staterFunc.time == StaterFunc.Time.Enter)
				{
					staterFunc.vFunc();
				}
				staterFunc.called = false;
			}
			this.m_StepTime = 0.0f;
		}

		public void Step(float dt)
		{
			this.m_StepTime += dt;
			foreach (StaterFunc staterFunc in this.m_Funcs)
			{
				if (staterFunc.time == StaterFunc.Time.AtStep)
				{
					float f = staterFunc.f0;
					if (!staterFunc.called && this.StepTime >= f)
					{
						staterFunc.called = true;
						staterFunc.vFunc();
					}
				}
				else if (staterFunc.time == StaterFunc.Time.Step)
				{
					staterFunc.vFunc();
				}
			}
		}

		public void Trigger(string triggerID)
		{
			bool flag = false;
			foreach (StaterFunc staterFunc in this.m_Funcs)
			{
				if (staterFunc.time == StaterFunc.Time.OnTrigger && staterFunc.s0 == triggerID)
				{
					staterFunc.vFunc();
					flag = true;
				}
			}
			if (!flag)
			{
				string format = "{0} does not handle trigger \"{1}\"!";
				object[] array = new object[2];
				int num = 0;
				StateID id = this.State;
				array[num] = id.ToString();
				array[1] = triggerID;
				Debug.LogWarningFormat(format, array);
			}
		}

		public void Exit()
		{
			foreach (StaterFunc staterFunc in this.m_Funcs)
			{
				if (staterFunc.time == StaterFunc.Time.Exit)
				{
					staterFunc.vFunc();
				}
			}
		}
	}
}
