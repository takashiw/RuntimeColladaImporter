using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterAnimationStates {Standing, Faint, Hit, Intro, Attack_1}

public class MonsterAnimationController : MonoBehaviour {

	Animator animator;

	// Update is called once per frame
	void Update () {
		if(this.animator == null) {
			getAnimationController();
		}
	}

	void getAnimationController() {
		Animator animator = this.GetComponentInChildren<Animator>();
		this.animator = animator;
	}

	public void playMonsterAnimation(MonsterAnimationStates state) {
		print("Playing animation for " + state.ToString().ToLower());
		this.animator.SetTrigger(state.ToString().ToLower());
	}

	// UnityEditor test method
	public void playMonsterAnimation(string state) {
		print("Playing animation for " + state);
		this.animator.SetTrigger(state.ToString());
	}
}
