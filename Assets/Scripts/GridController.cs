using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public float TilePositioningCoefficient;
    public List<TileController> Tiles;
    public int xSize = 4;
    public int ySize = 4;

    private void Start()
    {
        InitializeTiles();
        SetGridInitialPosition();
    }

    private void InitializeTiles()
    {
        SetTilesInitialPosition();
    }

    private void SetTilesInitialPosition()
    {
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                TileController tile = Tiles[x + y * ySize];
                tile.SetPosition(x, y, TilePositioningCoefficient);
            }
        }
    }

    private void SetGridInitialPosition()
    {
        transform.localPosition = new Vector3((-(xSize / 2f) * TilePositioningCoefficient) + (TilePositioningCoefficient / 2f),
                                              ((ySize / 2f) * TilePositioningCoefficient) - (TilePositioningCoefficient / 2f));
    }
}