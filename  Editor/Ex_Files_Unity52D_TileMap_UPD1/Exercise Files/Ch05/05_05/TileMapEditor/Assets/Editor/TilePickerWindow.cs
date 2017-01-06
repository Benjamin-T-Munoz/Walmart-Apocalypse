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

	public Vector2 scrollPosition = Vector2.zero;

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

				var viewPort = new Rect(0,0, position.width-5, position.height-5);
				var contentSize = new Rect(0,0, newTextureSize.x + offset.x, newTextureSize.y + offset.y);
				scrollPosition = GUI.BeginScrollView(viewPort, scrollPosition, contentSize);
				GUI.DrawTexture(new Rect(offset.x, offset.y , newTextureSize.x, newTextureSize.y), texture2D);
				GUI.EndScrollView();
			}
		}
	}
}
