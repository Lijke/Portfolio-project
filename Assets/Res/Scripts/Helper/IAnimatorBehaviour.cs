	using UnityEngine;
	
	[System.Serializable]
	public class StateInfo {
		public AnimatorStateInfo info;
		public int layer;
		public Animator animator;
	}

	public interface IAnimatorBehavior : IAnimatorOnStateEnter, IAnimatorOnStateExit, IAnimatorOnStateUpdate {


	}

	public interface IAnimatorOnStateEnter {
		void OnStateEnter(StateInfo info);
	}

	public interface IAnimatorOnStateExit {
		void OnStateExit(StateInfo info);
	}

	public interface IAnimatorOnStateUpdate {
		void OnStateUpdate(StateInfo info);
	}