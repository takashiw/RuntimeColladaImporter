using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleImporter : MonoBehaviour {

	// Public variables
	public string assetBundleFileName;	// File name (example: Machop.monster)
	public string assetObjectName;		// What the GameObject was named (example: Monster)	

	void Start () {
		// TODO : Determine filePath for Android aka where Application.persistentDataPath leads to
		string filePath = "file://" + Application.persistentDataPath + "/" + this.assetBundleFileName;
		print("FilePath is accessing here: " + filePath);

		StartCoroutine(FetchAssetBundle(filePath));
	}

	IEnumerator FetchAssetBundle(string filePath){
		WWW www = new WWW(filePath);
		yield return www;
		AssetBundle bundle = www.assetBundle;

		if(www.error == null) {
			print("Asset bundle was found!");
			GameObject importedAsset = (GameObject)bundle.LoadAsset(this.assetObjectName);
			GameObject instantiatedAsset = Instantiate(importedAsset);
			instantiatedAsset.transform.parent = this.gameObject.transform;
		} else {
			print(www.error);
		}
	}
}
