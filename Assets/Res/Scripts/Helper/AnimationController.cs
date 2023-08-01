using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController :  StateMachineBehaviour {
  	    bool check = false;
  		public IAnimatorBehavior behaviourReceiver;
  		StateInfo infoEnter = new StateInfo();
  		StateInfo infoExit = new StateInfo();
  		StateInfo infoUpdate = new StateInfo();
  		
  		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  			if (behaviourReceiver == null && !check) {
  				behaviourReceiver = animator.gameObject.GetComponent<IAnimatorBehavior>();
	             check = true;
  			}
  			if (behaviourReceiver != null) {
  				infoEnter.info = stateInfo;
  				infoEnter.animator = animator;
  				infoEnter.layer = layerIndex;
  				behaviourReceiver.OnStateEnter(infoEnter);
  			}
  		}
  
  		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  			if (behaviourReceiver == null && !check) {
  				behaviourReceiver = animator.gameObject.GetComponent<IAnimatorBehavior>();
  				check = true;
  			}
  			if (behaviourReceiver != null) {
  				infoUpdate.info = stateInfo;
  				infoUpdate.animator = animator;
  				infoUpdate.layer = layerIndex;
  				behaviourReceiver.OnStateUpdate(infoUpdate);
  			}
  		}
  
  		// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  		override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  			if (behaviourReceiver == null && !check) {
  				behaviourReceiver = animator.gameObject.GetComponent<IAnimatorBehavior>();
  				check = true;
  			}
  			if (behaviourReceiver != null) {
  				infoExit.info = stateInfo;
  				infoExit.animator = animator;
  				infoExit.layer = layerIndex;
  				behaviourReceiver.OnStateExit(infoExit);
  			}
  		}
  
  		// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
  		//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  		//
  		//}
  
  		// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
  		//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  		//
  		//}
  
}
