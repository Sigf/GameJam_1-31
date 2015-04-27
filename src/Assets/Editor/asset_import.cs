
using UnityEngine;
using UnityEditor;
using System.Collections;

public class charAnimationData {
	public Sprite[][] animationList = new Sprite[10][];
	public int[] numFrames = new int[10];
	public string[] description = new string[10]
	{
		"Spawn Animation",
		"Idle Animation",
		"Walk Animation",
		"Take Damage Animation",
		"Ray Atk Animation",
		"Projectile Atk Animation",
		"AOE Atk Animation",
		"Victory Animation",
		"Defeat Animation",
		"Death Animation"
	};
}

public class asset_import : EditorWindow {

	private int selectedType = 0;
	//private bool tileSet = false;
	private bool destructible = false;
	private int hp;
	private int numFrames;
	private string objectName = "";
	private string[] types = new string[]{"Floor", "Wall", "Door", "Obstacle", "Enemy", "Playable Character"};

	private charAnimationData data = new charAnimationData();
	private Sprite singleSprite;
	private Sprite[] animation;

	[MenuItem("Window/Asset Import")]
	public static void ShowWindow() 
	{
		EditorWindow.GetWindow (typeof(asset_import));
	}

	void OnGUI()
	{

		GUILayout.Label ("Import Settings", EditorStyles.boldLabel);
		selectedType = EditorGUILayout.Popup("Type", selectedType, types);

		if(selectedType == 0)
		{
			DisplayFloorOptions ();
		}

		if(selectedType == 1)
		{
			DisplayWallOptions ();
		}

		if(selectedType == 2)
		{
			DisplayDoorOptions();
		}

		if(selectedType == 3)
		{
			DisplayObstacleOptions();
		}

		if(selectedType == 4)
		{
			DisplayEnemyOptions ();
		}

		if(selectedType == 5)
		{
			DisplayPlayableOptions();
		}

		if (GUILayout.Button ("Import")) 
		{
			if(selectedType == 0)
			{
				if(objectName == "")
				{
					Debug.LogError ("Please enter a valid name");
				}

				else if(singleSprite == null)
				{
					Debug.LogError("Please assign a sprite");
				}

				else
				{
					CreateFloorPrefab();
				}
			}

			if(selectedType == 1)
			{
				if(objectName == "")
				{
					Debug.LogError ("Please enter a valid name");
				}

				else if(singleSprite == null)
				{
					Debug.LogError("Please assign a sprite");
				}

				else
				{
					CreateWallPrefab();
				}
            }

			if(selectedType == 2)
			{
				if(objectName == "")
				{
					Debug.LogError ("Please enter a valid name");
				}

				else if(singleSprite == null)
				{
					Debug.LogError("Please assign a sprite");
				}

				else
				{
					CreateDoorPrefab();
				}
            }

			if(selectedType == 3)
			{
				if(objectName == "")
				{
					Debug.LogError ("Please enter a valid name");
				}

				else if(singleSprite == null)
				{
					Debug.LogError("Please assign a sprite");
				}

				else
				{
					CreateObstaclePrefab();
				}
            }
			if(selectedType == 4)
			{
				if(objectName == "")
				{
					Debug.LogError ("Please enter a valid name");
				}

				else if(singleSprite == null)
				{
					Debug.LogError("Please assign a sprite");
				}

				else
				{
					CreateEnemyPrefab();
				}
            }
			if(selectedType == 5)
			{
				if(objectName == "")
				{
					Debug.LogError ("Please enter a valid name");
				}

				else if(singleSprite == null)
				{
					Debug.LogError("Please assign a sprite");
				}

				else
				{
					CreatePlayablePrefab();
				}
            }
		}
	}

	private void DisplayFloorOptions()
	{
		objectName = EditorGUILayout.TextField("Name", objectName);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Floor Sprite", singleSprite, typeof(Sprite), false);
	}

	private void DisplayWallOptions()
	{
		objectName = EditorGUILayout.TextField("Name", objectName);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Wall Sprite", singleSprite, typeof(Sprite), false);
		destructible = EditorGUILayout.Toggle("Destructible?", destructible);


		if(destructible)
		{
			hp = EditorGUILayout.IntField("Total HP", hp);
			numFrames = EditorGUILayout.IntField("How Many Frames?", numFrames);

			if(numFrames > 0 && (animation == null || animation.Length != numFrames))
			{
				animation = new Sprite[numFrames];
			}

			for(int i = 0; i < numFrames; i++)
			{
				animation[i] = (Sprite)EditorGUILayout.ObjectField("Level " + (i + 1), animation[i], typeof(Sprite), false);
            }

        }

    }


	private void DisplayDoorOptions()
	{
		objectName = EditorGUILayout.TextField("Name", objectName);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Closed Door", singleSprite, typeof(Sprite), false);
		numFrames = EditorGUILayout.IntField("How Many Frames?", numFrames);

		if(numFrames > 0 && (animation == null || animation.Length != numFrames))
		{
			animation = new Sprite[numFrames];
		}
		for(int i = 0; i < numFrames; i++)
		{
			animation[i] = (Sprite)EditorGUILayout.ObjectField("Level " + (i + 1), animation[i], typeof(Sprite), false);
		}

	}

	private void DisplayObstacleOptions()
	{
		objectName = EditorGUILayout.TextField("Name", objectName);
		singleSprite = (Sprite)EditorGUILayout.ObjectField("Floor Sprite", singleSprite, typeof(Sprite), false);
	}

	private void DisplayEnemyOptions()
	{
		objectName = EditorGUILayout.TextField("Name", objectName);
	}

	private void DisplayPlayableOptions()
	{
		objectName = EditorGUILayout.TextField("Name", objectName);

		for(int i = 0; i < data.numFrames.Length; i++)
		{
			data.numFrames[i] = EditorGUILayout.IntField(data.description[i] + " Frames", data.numFrames[i]);
			if(data.animationList[i] == null || data.animationList[i].Length != data.numFrames[i])
			{
				data.animationList[i] = new Sprite[data.numFrames[i]];
			}

			for(int j = 0; j < data.numFrames[i]; j++)
			{
				data.animationList[i][j] = (Sprite)EditorGUILayout.ObjectField("Frame " + (j + 1), data.animationList[i][j], typeof(Sprite), false);
			}

		}

	}
    
    private void CreateFloorPrefab()
	{
		Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Floor Tiles/" + objectName + ".prefab");

		GameObject newObject = new GameObject();

		SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = singleSprite;

		BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		bc.size = singleSprite.bounds.size;

		PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
		DestroyImmediate (newObject);

        this.Close();
    }

    private void CreateWallPrefab()
	{
		Object newPrefab;
		if(destructible && numFrames > 0)
		{
			AssetDatabase.CreateFolder("Assets/Prefabs/Level/Wall Tiles/Destructible", objectName);
			newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/Destructible/" + objectName + "/" + objectName + ".prefab");

			GameObject newObject = new GameObject();

			SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
			sr.sprite = singleSprite;

			BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
			bc.size = singleSprite.bounds.size;

			destructible_block_behavior dbb = newObject.AddComponent<destructible_block_behavior>() as destructible_block_behavior;
			dbb.destructionSprites = new Sprite[numFrames];
			dbb.totalHealth = hp;

			for(int i = 0; i < numFrames; i++)
			{
				dbb.destructionSprites[i] = animation[i];
			}

			newObject.layer = 8;
			newObject.tag = "Obstacles";

			PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);
            
			DestroyImmediate (newObject);

			System.Array.Clear (animation, 0, numFrames);
		}

		else
		{
			newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Wall Tiles/" + objectName + ".prefab");

			GameObject newObject = new GameObject();

			SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
			sr.sprite = singleSprite;

			BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
			bc.size = singleSprite.bounds.size;

			newObject.layer = 8;
			newObject.tag = "Obstacles";

			PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);

            DestroyImmediate (newObject);


		}

		this.Close();

	}

        
    

	private void CreateDoorPrefab()
	{
		AssetDatabase.CreateFolder("Assets/Prefabs/Level/Doors", objectName);

		Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Level/Doors/" + objectName + "/" + objectName + ".prefab");

		GameObject newObject = new GameObject();

		SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = singleSprite;

		BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		bc.size = singleSprite.bounds.size;

		door_behavior db = newObject.AddComponent<door_behavior>() as door_behavior;
		db.open_spr = singleSprite; 
		db.close_spr = animation[numFrames - 1];

		PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);

		DestroyImmediate (newObject);

		System.Array.Clear (animation, 0, numFrames);

		this.Close();
	}

	private void CreateObstaclePrefab()
	{
		Object newPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Obstacles/" + objectName + ".prefab");

		GameObject newObject = new GameObject();

		SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = singleSprite;

		BoxCollider2D bc = newObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		bc.size = singleSprite.bounds.size;

		GameObject path = (GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Path.prefab", typeof(GameObject));

		GameObject pathInstance = (GameObject)Instantiate(path, newObject.transform.position, Quaternion.identity);
		pathInstance.transform.parent = newObject.transform;

		followPath fp = newObject.AddComponent<followPath>() as followPath;
		fp.path = pathInstance.GetComponent<definePath>();

		obstacleAI ai = newObject.AddComponent<obstacleAI>() as obstacleAI;

		PrefabUtility.ReplacePrefab(newObject, newPrefab, ReplacePrefabOptions.ConnectToPrefab);

		DestroyImmediate (newObject);

		this.Close();
	}

	private void CreateEnemyPrefab(){
		this.Close();
	}

	private void CreatePlayablePrefab(){
		this.Close();
	}
}
