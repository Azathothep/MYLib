using System;
using System.Collections.Generic;
using UnityEngine;

namespace MY.States
{
	public class Stater<StateID> where StateID : struct, IConvertible
	{
		private string m_DebugName;
		public static bool EnableDebugLog;

		private StaterState<StateID> m_CurState;

		private static StateID m_DefaultState = Activator.CreateInstance<StateID>();

		private Dictionary<StateID, StaterState<StateID> > m_States = new Dictionary<StateID, StaterState<StateID> >();

		public Stater(string _debugName)
		{
			this.m_DebugName = _debugName;
		}

		public StateID CurState
		{
			get
			{
				return (this.m_CurState == null) ? Stater<StateID>.m_DefaultState : this.m_CurState.State;
			}
		}

		public float StateTime => (this.m_CurState == null) ? 0.0f : this.m_CurState.StepTime;

		public StaterState<StateID> AddState(StateID stateID)
		{
			StaterState<StateID> staterState = new StaterState<StateID>(stateID);
			this.m_States.Add(stateID, staterState);
			if (this.m_CurState == null)
			{
				this.m_CurState = staterState;
			}
			return staterState;
		}

		public StaterState<StateID> GetState(StateID stateID)
		{
			StaterState<StateID> result = null;
			this.m_States.TryGetValue(stateID, out result);
			return result;
		}

		public void Go(StateID stateID)
		{
			StaterState<StateID> state = this.GetState(stateID);
			if (state == null)
			{
				Debug.LogErrorFormat("{0}: State not found: {1}", new object[]
				{
					this.m_DebugName,
					stateID.ToString()
				});
				return;
			}

			if (Stater<StateID>.EnableDebugLog)
			{
				string format = "{0}: {1} -> {2}";
				object[] array = new object[3];
				array[0] = this.m_DebugName;
				int num = 1;
				object obj;
				if (this.m_CurState != null)
				{
					StateID id = this.m_CurState.State;
					obj = id.ToString();
				} else
				{
					obj = "-";
				}
				array[num] = obj;
				array[2] = stateID;
				Debug.LogFormat(format, array);
			}

			if (this.m_CurState != null)
			{
				this.m_CurState.Exit();
			}

			this.m_CurState = state;
			this.m_CurState.Enter();
		}

		public void Trigger(string triggerID)
		{
			if (Stater<StateID>.EnableDebugLog)
			{
				Debug.LogFormat("{0}: Trigger [{1}]", new object[]
				{
					this.m_DebugName,
					triggerID
				});
			}

			if (this.m_CurState != null)
			{
				this.m_CurState.Trigger(triggerID);
			}
		}

		public void Step(float dt)
		{
			if (this.m_CurState == null)
			{
				return;
			}

			if (this.m_CurState.StepDuration >= 0.0f
				&& this.m_CurState.HasAfterState
				&& this.m_CurState.StepTime >= this.m_CurState.StepDuration)
			{
				this.Go(this.m_CurState.AfterState);
			} else
			{
				this.m_CurState.Step(dt);
			}
		}
	}
}
