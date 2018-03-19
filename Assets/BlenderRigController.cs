using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderRigController : MonoBehaviour {

	public string blenderFileName = "SquirtleRigged";
	Animator animator;

	// Use this for initialization
	void Start () {
		GameObject madeBlender = Instantiate((GameObject)Resources.Load(blenderFileName));
		madeBlender.transform.parent = this.transform;
		Object[] animationsFromFile = Resources.LoadAll(blenderFileName, typeof(AnimationClip));
		Dictionary<string, AnimationClip> importedAnimations = new Dictionary<string, AnimationClip>();
		foreach(var animationObject in animationsFromFile) {
			AnimationClip animation = (AnimationClip)animationObject;
			print(animation.name);
			importedAnimations.Add(animation.name, animation);
		}

		animator = GetComponentInChildren<Animator>();
		animator.runtimeAnimatorController = Resources.Load("BlendController") as RuntimeAnimatorController;
		AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
		foreach (var motion in aoc.animationClips) {
			if(importedAnimations.ContainsKey(motion.name)) {
				aoc[motion.name] = importedAnimations[motion.name];
			}
		}
		animator.runtimeAnimatorController = aoc;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void playAnimation(string triggerName) {
		animator.SetTrigger(triggerName);
	}
}
