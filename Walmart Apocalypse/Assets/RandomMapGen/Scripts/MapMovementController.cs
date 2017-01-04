using UnityEngine;
using System.Collections;
using System;

public class MapMovementController : MonoBehaviour {

	public Map map;
	public Vector2 tileSize;
    public int currentTile;

    public float speed = 1f;
    public bool moving;
    public int[] blockedTileTypes;

    public delegate void TileAction(int Type);
    public TileAction tileActionCallback;

    public delegate void MoveAction();
    public MoveAction moveActionCallback;

    private float movetime;
    private Vector2 startPos;
    private Vector2 endPos;
    private int tmpIndex;
	private int tmpX;
	private int tmpY;

	public void MoveTo(int index,bool animate = false){

        if (!CanMove(index))
        {
            return;
        }
        
        if (moveActionCallback != null)
        {
            moveActionCallback();
        }
         
        currentTile = index;

		PosUtil.CalculatePos(index, map.columns, out tmpX, out tmpY);
		tmpX *= (int)tileSize.x;
		tmpY *= -(int)tileSize.y;

        var newPos = new Vector3(tmpX, tmpY, 0);

        if(!animate)
        {
            transform.position = newPos;

            if(tileActionCallback != null)
            {
                tileActionCallback(map.tiles[currentTile].autotileID);
            }
        }
        
        else
        {
            startPos = transform.position;
            endPos = newPos;
            movetime = 0;
            moving = true;

        }


    }
    
    public void MoveInDirection(Vector2 dir)
    {
        PosUtil.CalculatePos(currentTile, map.columns, out tmpX, out tmpY);

        tmpX += (int)dir.x;
        tmpY += (int)dir.y;

        PosUtil.CalculateIndex(tmpX, tmpY, map.columns, out tmpIndex);


        MoveTo(tmpIndex,true);
    }

    void Update()
    {
        if (moving)
        {
            movetime += Time.deltaTime;

            if(movetime>speed)
            {
                moving = false;
                transform.position = endPos;
                tileActionCallback(map.tiles[currentTile].autotileID);
            }

            transform.position = Vector2.Lerp(startPos, endPos, movetime / speed);
        }
    }

    private bool CanMove(int index)
    {
        if(index <0 || index>= map.tiles.Length )
        {
            return false;
        }

        var tileType = map.tiles[index].autotileID;

        if (moving || Array.IndexOf( blockedTileTypes,tileType)>-1)
        {
            return false;
        }

        return true;
    }
}

