using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {

	public TileMap map;

	public override void OnInspectorGUI(){
		EditorGUILayout.BeginVertical ();
		map.mapSize = EditorGUILayout.Vector2Field ("Map Size:", map.mapSize);
		map.texture2D = (Texture2D)EditorGUILayout.ObjectField ("Texture2D:", map.texture2D, typeof(Texture2D), false);

		if (map.texture2D == null) {
			EditorGUILayout.HelpBox ("You have not selected a texture 2D yet.", MessageType.Warning);
		} else {
			EditorGUILayout.LabelField("Tile Size:", map.tileSize.x+"x"+map.tileSize.y);
			EditorGUILayout.LabelField("Grid Size In Units:", map.gridSize.x+"x"+map.gridSize.y);
		}

		EditorGUILayout.EndVertical ();
	}

	void OnEnable(){
		map = target as TileMap;
		Tools.current = Tool.View;

		if (map.texture2D != null) {
			var path = AssetDatabase.GetAssetPath(map.texture2D);
			map.spriteReferences = AssetDatabase.LoadAllAssetsAtPath(path);

			var sprite = (Sprite)map.spriteReferences[1];
			var width = sprite.textureRect.width;
			var height = sprite.textureRect.height;

			map.tileSize = new Vector2(width, height);

			map.gridSize = new Vector2((width / 100) * map.mapSize.x, (height/100) * map.mapSize.y);

		}



	}
}
