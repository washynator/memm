using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public GameObject groundTilePrefab;
    public static GameObject[,] groundTiles;

    private int mapX = 50;
    private int mapY = 50;

	void Awake ()
	{
        Instance = this;

        groundTiles = new GameObject[mapX, mapY];

		for (int x = 0; x < mapX; x++)
        {
            for(int y = 0; y < mapY; y++)
            {
                CreateGround(x, y);
            }
        }
	}

    public GameObject GetCurrentTile(int x, int y)
    {
        return groundTiles[x, y];
    }

    private void CreateGround(int _x, int _y)
    {
        GameObject ground = (GameObject)Instantiate(groundTilePrefab, new Vector3(_x, 0f, _y), Quaternion.Euler(90f, 0, 0));
        groundTiles[_x, _y] = ground;
        ground.name = "Ground tile (" + _x + ", " + _y + ")";
        ground.transform.parent = this.transform;
    }
}
