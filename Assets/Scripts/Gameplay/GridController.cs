using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [Header("Parameters")]
    public float TilePositioningCoefficient;
    public float SlideAnimationDuration;
    public int xSize = 4;
    public int ySize = 4;

    [Header("References")]
    public List<TileController> Tiles;
    public Transform VisibleTopLeft;
    public Transform VisibleTopRight;
    public Transform VisibleBottomLeft;
    public Transform VisibleBottomRight;

    private bool isAnimationPlayingNow = false;



    public void Initialize(Level level)
    {
        InitializeTiles(level);
        SetGridInitialPosition();
    }

    public void MoveColumnUp(int columnIndex)
    {
        if (isAnimationPlayingNow == true)
            return;

        GetTileByIndex(columnIndex, 0).SetVisualPositionY(GetInvisibleBottomYPosition());
        GetTileByIndex(columnIndex, 0).MoveTo(Direction.Up, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(columnIndex, 1).MoveTo(Direction.Up, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(columnIndex, 2).MoveTo(Direction.Up, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(columnIndex, 3).MoveTo(Direction.Up, TilePositioningCoefficient, SlideAnimationDuration);

        isAnimationPlayingNow = true;

        StartCoroutine(CallbackAfterAnimationDelay(() =>
        {
            TileConfiguration tempConfiguration = GetTileByIndex(columnIndex, 0).Configuration;

            GetTileByIndex(columnIndex, 0).Configuration = GetTileByIndex(columnIndex, 1).Configuration;
            GetTileByIndex(columnIndex, 1).Configuration = GetTileByIndex(columnIndex, 2).Configuration;
            GetTileByIndex(columnIndex, 2).Configuration = GetTileByIndex(columnIndex, 3).Configuration;
            GetTileByIndex(columnIndex, 3).Configuration = tempConfiguration;

            GetTileByIndex(columnIndex, 0).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 3).transform, false);
            GetTileByIndex(columnIndex, 1).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 0).transform, false);
            GetTileByIndex(columnIndex, 2).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 1).transform, false);
            GetTileByIndex(columnIndex, 3).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 2).transform, false);

            SetAllTilesVisualGameObjectsLocalPositionsToZero();
            ReassignAllTilesVisualGameObjects();

            isAnimationPlayingNow = false;
        }));
    }

    public void MoveColumnDown(int columnIndex)
    {
        if (isAnimationPlayingNow == true)
            return;

        GetTileByIndex(columnIndex, 3).SetVisualPositionY(GetInvisibleTopYPosition());
        GetTileByIndex(columnIndex, 0).MoveTo(Direction.Down, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(columnIndex, 1).MoveTo(Direction.Down, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(columnIndex, 2).MoveTo(Direction.Down, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(columnIndex, 3).MoveTo(Direction.Down, TilePositioningCoefficient, SlideAnimationDuration);

        isAnimationPlayingNow = true;

        StartCoroutine(CallbackAfterAnimationDelay(() =>
        {
            TileConfiguration tempConfiguration = GetTileByIndex(columnIndex, 3).Configuration;

            GetTileByIndex(columnIndex, 3).Configuration = GetTileByIndex(columnIndex, 2).Configuration;
            GetTileByIndex(columnIndex, 2).Configuration = GetTileByIndex(columnIndex, 1).Configuration;
            GetTileByIndex(columnIndex, 1).Configuration = GetTileByIndex(columnIndex, 0).Configuration;
            GetTileByIndex(columnIndex, 0).Configuration = tempConfiguration;

            GetTileByIndex(columnIndex, 3).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 0).transform, false);
            GetTileByIndex(columnIndex, 2).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 3).transform, false);
            GetTileByIndex(columnIndex, 1).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 2).transform, false);
            GetTileByIndex(columnIndex, 0).VisualGameObject.transform.SetParent(GetTileByIndex(columnIndex, 1).transform, false);

            SetAllTilesVisualGameObjectsLocalPositionsToZero();
            ReassignAllTilesVisualGameObjects();

            isAnimationPlayingNow = false;
        }));
    }

    public void MoveRowLeft(int rowIndex)
    {
        if (isAnimationPlayingNow == true)
            return;

        GetTileByIndex(0, rowIndex).MoveTo(Direction.Left, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(1, rowIndex).MoveTo(Direction.Left, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(2, rowIndex).MoveTo(Direction.Left, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(3, rowIndex).MoveTo(Direction.Left, TilePositioningCoefficient, SlideAnimationDuration);

        isAnimationPlayingNow = true;

        StartCoroutine(CallbackAfterAnimationDelay(() =>
        {
            TileConfiguration tempConfiguration = GetTileByIndex(0, rowIndex).Configuration;

            GetTileByIndex(0, rowIndex).Configuration = GetTileByIndex(1, rowIndex).Configuration;
            GetTileByIndex(1, rowIndex).Configuration = GetTileByIndex(2, rowIndex).Configuration;
            GetTileByIndex(2, rowIndex).Configuration = GetTileByIndex(3, rowIndex).Configuration;
            GetTileByIndex(3, rowIndex).Configuration = tempConfiguration;

            GetTileByIndex(0, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(3, rowIndex).transform, false);
            GetTileByIndex(1, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(0, rowIndex).transform, false);
            GetTileByIndex(2, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(1, rowIndex).transform, false);
            GetTileByIndex(3, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(2, rowIndex).transform, false);

            SetAllTilesVisualGameObjectsLocalPositionsToZero();
            ReassignAllTilesVisualGameObjects();

            isAnimationPlayingNow = false;
        }));
    }

    public void MoveRowRight(int rowIndex)
    {
        if (isAnimationPlayingNow == true)
            return;

        GetTileByIndex(0, rowIndex).MoveTo(Direction.Right, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(1, rowIndex).MoveTo(Direction.Right, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(2, rowIndex).MoveTo(Direction.Right, TilePositioningCoefficient, SlideAnimationDuration);
        GetTileByIndex(3, rowIndex).MoveTo(Direction.Right, TilePositioningCoefficient, SlideAnimationDuration);

        isAnimationPlayingNow = true;

        StartCoroutine(CallbackAfterAnimationDelay(() =>
        {
            TileConfiguration tempConfiguration = GetTileByIndex(3, rowIndex).Configuration;

            GetTileByIndex(3, rowIndex).Configuration = GetTileByIndex(2, rowIndex).Configuration;
            GetTileByIndex(2, rowIndex).Configuration = GetTileByIndex(1, rowIndex).Configuration;
            GetTileByIndex(1, rowIndex).Configuration = GetTileByIndex(0, rowIndex).Configuration;
            GetTileByIndex(0, rowIndex).Configuration = tempConfiguration;

            GetTileByIndex(3, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(0, rowIndex).transform, false);
            GetTileByIndex(2, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(3, rowIndex).transform, false);
            GetTileByIndex(1, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(2, rowIndex).transform, false);
            GetTileByIndex(0, rowIndex).VisualGameObject.transform.SetParent(GetTileByIndex(1, rowIndex).transform, false);

            SetAllTilesVisualGameObjectsLocalPositionsToZero();
            ReassignAllTilesVisualGameObjects();

            isAnimationPlayingNow = false;
        }));
    }

    /*
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
    */



    private void InitializeTiles(Level level)
    {
        SetTilesInitialPosition();
        PopulateTilesByLevel(level);
    }

    private void SetTilesInitialPosition()
    {
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                TileController tile = Tiles[x + y * xSize];
                tile.SetPosition(x, y, TilePositioningCoefficient);
            }
        }
    }

    private void PopulateTilesByLevel(Level level)
    {
        for (int i = 0; i < level.TileConfigurations.Length; i++)
        {
            TileConfiguration tileConfiguration = level.TileConfigurations[i];
            TileController tile = Tiles[i];

            tile.Populate(tileConfiguration);
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
        return Tiles[xIndex + yIndex * xSize];
    }

    private float GetInvisibleTopYPosition()
    {
        return -4 * TilePositioningCoefficient;
    }

    private float GetInvisibleRightXPosition()
    {
        return 4 * TilePositioningCoefficient;
    }

    private float GetInvisibleBottomYPosition()
    {
        return 4 * TilePositioningCoefficient;
    }

    private float GetInvisibleLeftXPosition()
    {
        return -4 * TilePositioningCoefficient;
    }

    private void SetAllTilesVisualGameObjectsLocalPositionsToZero()
    {
        foreach (TileController tile in Tiles)
        {
            tile.VisualGameObject.transform.localPosition = Vector3.zero;
        }
    }

    private void ReassignAllTilesVisualGameObjects()
    {
        foreach (TileController tile in Tiles)
        {
            tile.VisualGameObject = tile.transform.GetChild(0).gameObject;
        }
    }

    private IEnumerator CallbackAfterAnimationDelay(Action callback)
    {
        yield return new WaitForSeconds(SlideAnimationDuration);
        callback();
    }
}