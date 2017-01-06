using UnityEngine;
using System.Collections;
using UnityEditor;

public class TilePickerWindow : EditorWindow {

	[MenuItem("Window/Tile Picker")]
	public static void OpenTilePickerWindow(){
		var window = EditorWindow.GetWindow(typeof(TilePickerWindow));
		var title = new GUIContent ();
		title.text = "Tile Picker";
		window.titleContent = title;
	}

	void OnGUI(){
		if (Selection.activeGameObject == null)
			return;

		var selection = Selection.activeGameObject.GetComponent<TileMap> ();

		if (selection != null) {
			var texture2D = selection.texture2D;
			if(texture2D != null){
				GUI.DrawTexture(new Rect(0,0, texture2D.width, texture2D.height), texture2D);
			}
		}
	}
}
