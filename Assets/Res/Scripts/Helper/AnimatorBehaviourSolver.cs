
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


	[System.Serializable]
	public class IAnimationBehaviorEvent : UnityEvent<StateInfo> {

	}

	[System.Serializable]
	public class IAnimatorSolverSerialized {
		public UnityEngine.Object _component;

		private IAnimatorSolver _interface;
		public IAnimatorSolver Interface {
			get {
				if (_interface == null && _component != null) {
					_interface = _component as IAnimatorSolver;
				}
				return _interface;
			}

			set {
				_interface = value;
			}
		}

	}

	public interface IAnimatorSolver {
		IAnimationBehaviorEvent OnEnter { get; set; }
		IAnimationBehaviorEvent OnUpdate { get; set; }
		IAnimationBehaviorEvent OnExit { get; set; }
	}

	public class AnimatorBehaviourSolver : MonoBehaviour, IAnimatorBehavior, IAnimatorSolver {
		IAnimationBehaviorEvent onEnter;
		public IAnimationBehaviorEvent OnEnter {
			get {
				if (onEnter == null) {
					onEnter = new IAnimationBehaviorEvent();
				}
				return onEnter;
			}
			set {
				if (onEnter == null) {
					onEnter = new IAnimationBehaviorEvent();
				}
				onEnter = value;
			}
		}

		IAnimationBehaviorEvent onUpdate;
		public IAnimationBehaviorEvent OnUpdate {
			get {
				if (onUpdate == null) {
					onUpdate = new IAnimationBehaviorEvent();
				}
				return onUpdate;
			}
			set {
				if (onUpdate == null) {
					onUpdate = new IAnimationBehaviorEvent();
				}
				onUpdate = value;
			}
		}
		IAnimationBehaviorEvent onExit;
		public IAnimationBehaviorEvent OnExit {
			get {
				if (onExit == null) {
					onExit = new IAnimationBehaviorEvent();
				}
				return onExit;
			}
			set {
				if (onExit == null) {
					onExit = new IAnimationBehaviorEvent();
				}
				onExit = value;
			}
		}


		public void OnStateEnter(StateInfo info) {
			OnEnter?.Invoke(info);
		}

		public void OnStateExit(StateInfo info) {
			OnExit?.Invoke(info);
		}

		public void OnStateUpdate(StateInfo info) {
			OnUpdate?.Invoke(info);
		}
	}
