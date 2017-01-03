using UnityEngine;
using System.Collections;

public class MapMovementController : MonoBehaviour {

	public Map map;
	public Vector2 tileSize;

	private int tmpX;
	private int tmpY;

	public void MoveTo(int index){
		PosUtil.CalculatePos(index, map.columns, out tmpX, out tmpY);
		tmpX *= (int)tileSize.x;
		tmpY *= -(int)tileSize.y;

		Debug.Log (tmpX);
		Debug.Log (tmpY);

		transform.position = new Vector3 (tmpX, tmpY, 0);
	}
}

