using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public float TilePositioningCoefficient;
    public List<TileController> Tiles;
    public int xSize = 4;
    public int ySize = 4;
    public Transform VisibleTopLeft;
    public Transform VisibleTopRight;
    public Transform VisibleBottomLeft;
    public Transform VisibleBottomRight;



    void Start()
    {
        InitializeTiles();
        SetGridInitialPosition();
    }



    public void ArrangeGridByPlayerIndex(PlayerIndex playerIndex)
    {
        HideAllTiles();

        switch (playerIndex)
        {
            case PlayerIndex.TopLeft:
                GetTileByIndex(0, 0).SetPosition(VisibleTopLeft.position);
                GetTileByIndex(0, 1).SetPosition(VisibleTopRight.position);
                GetTileByIndex(1, 0).SetPosition(VisibleBottomLeft.position);
                GetTileByIndex(1, 1).SetPosition(VisibleBottomRight.position);

                GetTileByIndex(0, 0).Show();
                GetTileByIndex(0, 1).Show();
                GetTileByIndex(1, 0).Show();
                GetTileByIndex(1, 1).Show();
                break;

            case PlayerIndex.TopRight:
                GetTileByIndex(0, 2).SetPosition(VisibleTopLeft.position);
                GetTileByIndex(0, 3).SetPosition(VisibleTopRight.position);
                GetTileByIndex(1, 2).SetPosition(VisibleBottomLeft.position);
                GetTileByIndex(1, 3).SetPosition(VisibleBottomRight.position);

                GetTileByIndex(0, 2).Show();
                GetTileByIndex(0, 3).Show();
                GetTileByIndex(1, 2).Show();
                GetTileByIndex(1, 3).Show();
                break;

            case PlayerIndex.BottomLeft:
                GetTileByIndex(2, 0).SetPosition(VisibleTopLeft.position);
                GetTileByIndex(2, 1).SetPosition(VisibleTopRight.position);
                GetTileByIndex(3, 0).SetPosition(VisibleBottomLeft.position);
                GetTileByIndex(3, 1).SetPosition(VisibleBottomRight.position);

                GetTileByIndex(2, 0).Show();
                GetTileByIndex(2, 1).Show();
                GetTileByIndex(3, 0).Show();
                GetTileByIndex(3, 1).Show();
                break;

            case PlayerIndex.BottomRight:
                GetTileByIndex(2, 2).SetPosition(VisibleTopLeft.position);
                GetTileByIndex(2, 3).SetPosition(VisibleTopRight.position);
                GetTileByIndex(3, 2).SetPosition(VisibleBottomLeft.position);
                GetTileByIndex(3, 3).SetPosition(VisibleBottomRight.position);

                GetTileByIndex(2, 2).Show();
                GetTileByIndex(2, 3).Show();
                GetTileByIndex(3, 2).Show();
                GetTileByIndex(3, 3).Show();
                break;
        }
    }



    private void InitializeTiles()
    {
        AssignTilesIndex();
        SetTilesInitialPosition();
    }

    private void AssignTilesIndex()
    {
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                TileController tile = Tiles[x + y * ySize];
                tile.XIndex = x;
                tile.YIndex = y;
            }
        }
    }

    private void SetTilesInitialPosition()
    {
        foreach (TileController tile in Tiles)
        {
            tile.SetPosition(tile.XIndex, tile.YIndex, TilePositioningCoefficient);
        }
    }

    private void SetGridInitialPosition()
    {
        transform.localPosition = new Vector3((-(xSize / 2f) * TilePositioningCoefficient) + (TilePositioningCoefficient / 2f),
                                              ((ySize / 2f) * TilePositioningCoefficient) - (TilePositioningCoefficient / 2f));
    }

    private void HideAllTiles()
    {
        foreach (TileController tile in Tiles)
        {
            tile.Hide();
        }
    }

    private void ShowAllTiles()
    {
        foreach (TileController tile in Tiles)
        {
            tile.Show();
        }
    }

    private TileController GetTileByIndex(int xIndex, int yIndex)
    {
        return Tiles[xIndex + yIndex * ySize];
    }
}