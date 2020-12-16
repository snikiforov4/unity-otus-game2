using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapEditor : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(pos), tile);
        }
    }
}
