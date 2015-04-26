
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

	private int selectedType = 0;
	private bool tileSet = false;
	private bool destructible = false;
	private int numFrames;
	private string name;
	private string[] types = new string[]{"Floor", "Wall", "Door", "Obstacle", "Enemy", "Playable Character"};
	private string assetPath;
	private Texture2D assetTexture;
	private TextureImporter importer;

	private Sprite singleSprite;
	private Sprite[] tileSetSprites;
	private Sprite[] animationList;
	private Sprite[] animation;

	[MenuItem("Window/Asset Import")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(asset_import));
	}

	void OnGUI(){
		GUILayout.Label ("Import Settings", EditorStyles.boldLabel);
		selectedType = EditorGUILayout.Popup("Type", selectedType, types);

		if(selectedType == 0){
			DisplayFloorOptions ();
		}
		if(selectedType == 1){
			DisplayWallOptions ();
		}
		if(selectedType == 2){
			DisplayDoorOptions();
		}
		if(selectedType == 3){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}
		if(selectedType == 4){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}
		if(selectedType == 5){
			singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		}

		if (GUILayout.Button ("Import")) {
			if(selectedType == 0){
				CreateFloorPrefab();
			}
			if(selectedType == 1){
				CreateWallPrefab ();
            }
			if(selectedType == 2){
				CreateDoorPrefab();
            }
			if(selectedType == 3){
                
            }
			if(selectedType == 4){
                
            }
			if(selectedType == 5){
                
            }


		}
	}

	private void DisplayFloorOptions(){
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Floor Sprite", singleSprite, typeof(Sprite), false);
		name = EditorGUILayout.TextField("Name", name);
	}

	private void DisplayWallOptions(){
		name = EditorGUILayout.TextField("Name", name);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		destructible = EditorGUILayout.Toggle("Destructible?", destructible);


		if(destructible){
			numFrames = EditorGUILayout.IntField("How Many Frames?", numFrames);
			if(numFrames > 0 && (animation == null || animation.Length != numFrames)){
				animation = new Sprite[numFrames];
			}
			for(int i = 0; i < numFrames; i++){
				animation[i] = (Sprite)EditorGUILayout.ObjectField("Level " + (i + 1), animation[i], typeof(Sprite), false);
            }

        }
    }

	private void DisplayDoorOptions(){
		name = EditorGUILayout.TextField("Name", name);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Closed Door", singleSprite, typeof(Sprite), false);
		numFrames = EditorGUILayout.IntField("How Many Frames?", numFrames);
		if(numFrames > 0 && (animation == null || animation.Length != numFrames)){
			animation = new Sprite[numFrames];
		}
		for(int i = 0; i < numFrames; i++){
			animation[i] = (Sprite)EditorGUILayout.ObjectField("Level " + (i + 1), animation[i], typeof(Sprite), false);
		}
	}
    
    private void CreateFloorPrefab(){
		Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Floor Tiles/" + name + ".prefab");
		GameObject newObject = new GameObject();
		SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = singleSprite;
		BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
		DestroyImmediate (newObject);
        this.Close();
    }
    private void CreateWallPrefab(){
		Object newPrefab;
		if(destructible && numFrames > 0){
			string guid = AssetDatabase.CreateFolder("Assets/Prefabs/Level/Wall Tiles/Destructible", name);
			string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
			newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/Destructible/" + name + "/" + name + ".prefab");
			GameObject newObject = new GameObject();
			SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
			sr.sprite = singleSprite;
			BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
			destructible_block_behavior dbb = newObject.AddComponent<destructible_block_behavior>() as destructible_block_behavior;
			dbb.destructionSprites = new Sprite[numFrames];
			for(int i = 0; i < numFrames; i++){
				dbb.destructionSprites[i] = animation[i];
			}
			PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate (newObject);

			System.Array.Clear (animation, 0, numFrames);
		}

		else{
			newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/" + name + ".prefab");
			GameObject newObject = new GameObject();
			SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
			sr.sprite = singleSprite;
			BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
			PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate (newObject);
		}

        this.Close();
    }

	private void CreateDoorPrefab(){
		string guid = AssetDatabase.CreateFolder("Assets/Prefabs/Level/Doors", name);
		string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
		Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Doors/" + name + "/" + name + ".prefab");
		GameObject newObject = new GameObject();
		SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = singleSprite;
		BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		door_behavior db = newObject.AddComponent<door_behavior>() as door_behavior;
		db.open_spr = singleSprite;
		db.close_spr = animation[numFrames - 1];
		PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
		DestroyImmediate (newObject);
		System.Array.Clear (animation, 0, numFrames);

		this.Close();
	}
}
