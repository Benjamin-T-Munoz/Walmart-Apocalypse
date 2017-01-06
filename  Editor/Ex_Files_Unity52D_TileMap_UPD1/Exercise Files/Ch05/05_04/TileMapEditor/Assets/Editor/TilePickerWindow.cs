using UnityEngine;
using System.Collections;
using UnityEditor;

public class TilePickerWindow : EditorWindow {

	public enum Scale
	{
		x1,
		x2,
		x3,
		x4,
		x5
	}

	Scale scale;

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

				scale = (Scale)EditorGUILayout.EnumPopup("Zoom", scale);
				var newScale = ((int)scale) + 1;
				var newTextureSize = new Vector2(texture2D.width, texture2D.height) * newScale;
				var offset = new Vector2(10 , 25);
				GUI.DrawTexture(new Rect(offset.x, offset.y , newTextureSize.x, newTextureSize.y), texture2D);
			}
		}
	}
}
