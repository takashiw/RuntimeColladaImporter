using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveAssetBundles : EditorWindow {

	[MenuItem("Window/Save Asset Bundles 😍")]
	public static void Open() {
		BuildPipeline.BuildAssetBundles("Assets/AssetBundles/", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
		AssetDatabase.Refresh();
	}
}
