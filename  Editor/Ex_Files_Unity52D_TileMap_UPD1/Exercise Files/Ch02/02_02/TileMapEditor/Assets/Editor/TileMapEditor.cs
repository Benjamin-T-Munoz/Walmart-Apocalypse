using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {

	public override void OnInspectorGUI(){
		EditorGUILayout.LabelField ("Our custom editor");
	}
}
