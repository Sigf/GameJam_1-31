using UnityEngine;
using UnityEditor;
using System.Collections;

/*
 * This tool is to streamline the import of assets as they are for the most part
 * made of the same components. It will also set the correcct resolution and filter
 * mode. It will import the sprite to the sprite folder, create a prefab of of it and
 * put it in the ressource folder. It will give the user the option to add a collider.
 */

public class asset_import : EditorWindow {

	private string assetPath;
	private Texture2D assetTexture;
	private TextureImporter importer;

	[MenuItem("Window/Asset Import")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(asset_import));
	}

	void OnGUI(){
		GUILayout.Label ("Import Settings", EditorStyles.boldLabel);
		if (GUILayout.Button ("Select Asset")) {
			assetPath = EditorUtility.OpenFilePanel("Asset", "", "png");
		}

		if (GUILayout.Button ("Test")) {
			if (assetPath != "") {
				importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
				importer.mipmapEnabled = true;
				importer.isReadable = true;
				importer.maxTextureSize = 32;
				importer.filterMode = FilterMode.Point;
			}

			Debug.Log (assetPath);
		}
	}
}
