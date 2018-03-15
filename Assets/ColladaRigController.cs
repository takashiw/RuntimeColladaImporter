using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ColladaRigController : MonoBehaviour {

	public string path;

	// Use this for initialization
	void Start () {
		GameObject madeCollada = Instantiate((GameObject)Resources.Load("MachopStanding"));
		madeCollada.transform.parent = this.transform;

		Mesh m = (Mesh)Resources.Load("MachopStanding", typeof(Mesh));
		AnimationClip idle = (AnimationClip)Resources.Load("MachopStanding", typeof(AnimationClip));
		idle.wrapMode = WrapMode.Loop;
		AnimationClip attack = (AnimationClip)Resources.Load("MachopChop", typeof(AnimationClip));
		AnimationClip intro = (AnimationClip)Resources.Load("MachopIntro", typeof(AnimationClip));
		AnimationClip faint = (AnimationClip)Resources.Load("MachopFaint", typeof(AnimationClip));
		AnimationClip hit = (AnimationClip)Resources.Load("MachopHit", typeof(AnimationClip));
		AnimationClip[] animationClips = {idle, attack, intro, faint, hit};

		SkinnedMeshRenderer mesh = GetComponentInChildren<SkinnedMeshRenderer>();
		mesh.sharedMesh = m;
		mesh.materials = this.fetchMaterials().ToArray();

		Animator animator = GetComponentInChildren<Animator>();
		animator.runtimeAnimatorController = Resources.Load("CoolController") as RuntimeAnimatorController;
		
		AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
		var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
		// AnimatorControllerLayer[] layers = 
		int i = 0;
		foreach(AnimationClip animation in aoc.animationClips) {
			print(animation.ToString());
			
			anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(animation, animationClips[i]));
			i++;
		}
		aoc.ApplyOverrides(anims);
		animator.runtimeAnimatorController = aoc;

		// animator.SetTr
	}

	List<Material> fetchMaterials() {
		Texture bodyTexture = (Texture)Resources.Load("wanriky_0_1");
		Texture faceTexture = (Texture)Resources.Load("wanriky_0_0");

		Material body = new Material(Shader.Find("Standard"));
		Material face = new Material(Shader.Find("Standard"));
		body.mainTexture = bodyTexture;
		face.mainTexture = faceTexture;

		List<Material> importedMaterials = new List<Material>();
		importedMaterials.Add(body);
		importedMaterials.Add(face);

		return importedMaterials;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
