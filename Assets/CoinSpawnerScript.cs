using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinSpawnerScript : MonoBehaviour
{
    public GameObject borders;
    public GameObject coin;
    public BoundsInt area;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3Int cellPosition = new Vector3Int(2,2,0);
        //TileBase tilebase;
        Tilemap tilemap = borders.GetComponent<Tilemap>();
        area = tilemap.cellBounds;;

        for (int n = area.xMin;n <= area.xMax; n++)
        {
            for (int p = area.yMin; p <= area.yMax; p++)
            {
                Vector3Int cellCoordinates = new Vector3Int(n, p, 0);
                if (tilemap.HasTile(cellCoordinates) == false)
                {
                    Vector3 worldCoordinates = tilemap.CellToWorld(cellCoordinates);
                    if (worldCoordinates != new Vector3(0, -1, 0) && worldCoordinates != new Vector3(-1,-1,0))
                    {
                        Instantiate(coin, worldCoordinates + new Vector3(0.5f, 0.5f, 0), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
        }
        //tilebase = tilemap.GetTile(cellPosition);
        //print(tilebase);
        //TileBase[] tileArray = tilemap.GetTilesBlock(area);
        //for (int index = 0; index < tileArray.Length; index++)
        //{
        //    print(index + "," + tileArray[index]);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
