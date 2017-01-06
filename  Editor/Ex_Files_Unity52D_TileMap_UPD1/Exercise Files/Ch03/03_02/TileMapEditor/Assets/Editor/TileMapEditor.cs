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
		EditorGUILayout.EndVertical ();
	}

	void OnEnable(){
		map = target as TileMap;
		Tools.current = Tool.View;
	}
}
