using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClikerTileMap : MonoBehaviour
{

    public Transform Player;

    private Tilemap map;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clicWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int clicCellPosition = map.WorldToCell(clicWorldPosition);

            Vector3Int playerPositionInt = map.WorldToCell(Player.position);

            Vector3Int[] vectorsTrueArray = new Vector3Int[8]
            {
                new Vector3Int(playerPositionInt.x + 1, playerPositionInt.y, -5),
                new Vector3Int(playerPositionInt.x, playerPositionInt.y + 1, -5),
                new Vector3Int(playerPositionInt.x + 1, playerPositionInt.y + 1, -5),
                new Vector3Int(playerPositionInt.x - 1, playerPositionInt.y, -5),
                new Vector3Int(playerPositionInt.x, playerPositionInt.y - 1, -5),
                new Vector3Int(playerPositionInt.x - 1, playerPositionInt.y - 1, -5),
                new Vector3Int(playerPositionInt.x - 1, playerPositionInt.y + 1, -5),
                new Vector3Int(playerPositionInt.x + 1, playerPositionInt.y - 1, -5)
            };

            for (int i = 0; i < vectorsTrueArray.Length; i++)
            {
                if (clicCellPosition == vectorsTrueArray[i])
                {
                    Player.position = map.CellToWorld(clicCellPosition);
                }
            }
            Debug.Log(clicCellPosition);
        }
    }
}
