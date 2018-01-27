using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileController : MonoBehaviour
{
    public TilePrefabCollectionScriptableObject TilePrefabCollection;
    public TileConfiguration Configuration;
    public GameObject VisualGameObject;



    public void SetPosition(int x, int y, float coefficient)
    {
        transform.localPosition = new Vector3(x * coefficient, -y * coefficient);
    }

    public void SetPosition(Vector3 position)
    {
        transform.localPosition = new Vector3(position.x, position.y);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetVisualPositionX(float x)
    {
        VisualGameObject.transform.localPosition = new Vector3(x, VisualGameObject.transform.localPosition.y);
    }

    public void SetVisualPositionY(float y)
    {
        VisualGameObject.transform.localPosition = new Vector3(VisualGameObject.transform.localPosition.x, -y);
    }

    public void MoveTo(Direction direction, float distance, float duration)
    {
        switch (direction)
        {
            case Direction.Up:
                VisualGameObject.transform
                .DOLocalMove(new Vector3(0f, VisualGameObject.transform.localPosition.y + distance), duration)
                .SetEase(Ease.OutQuad);
                break;

            case Direction.Left:
                VisualGameObject.transform
                .DOLocalMove(new Vector3(VisualGameObject.transform.localPosition.x - distance, 0f), duration)
                .SetEase(Ease.OutQuad);
                break;

            case Direction.Down:
                VisualGameObject.transform
                .DOLocalMove(new Vector3(0f, VisualGameObject.transform.localPosition.y - distance), duration)
                .SetEase(Ease.OutQuad);
                break;

            case Direction.Right:
                VisualGameObject.transform
                .DOLocalMove(new Vector3(VisualGameObject.transform.localPosition.x + distance, 0f), duration)
                .SetEase(Ease.OutQuad);
                break;
        }
    }

    public void Populate(TileConfiguration configuration)
    {
        Configuration = configuration;

        GameObject prefab = null;
        float rotation = 0f;

        // Blocked
        if (configuration.Top == false
            && configuration.Right == false
            && configuration.Bottom == false
            && configuration.Left == false)
        {
            prefab = TilePrefabCollection.TileBlockedPrefab;
            rotation = 0f;
        }

        // Straight: Right & Left
        if (configuration.Right == true
            && configuration.Left == true
            && configuration.Bottom == false
            && configuration.Top == false)
        {
            prefab = TilePrefabCollection.TileStraightPrefab;
            rotation = 0f;
        }

        // Straight: Top & Bottom
        if (configuration.Right == false
            && configuration.Left == false
            && configuration.Bottom == true
            && configuration.Top == true)
        {
            prefab = TilePrefabCollection.TileStraightPrefab;
            rotation = 90f;
        }

        // L-Shape: Top & Right
        if (configuration.Top == true
            && configuration.Right == true
            && configuration.Bottom == false
            && configuration.Left == false)
        {
            prefab = TilePrefabCollection.TileLShapePrefab;
            rotation = 270f;
        }

        // L-Shape: Right & Bottom
        if (configuration.Top == false
            && configuration.Right == true
            && configuration.Bottom == true
            && configuration.Left == false)
        {
            prefab = TilePrefabCollection.TileLShapePrefab;
            rotation = 180f;
        }

        // L-Shape: Bottom & Left
        if (configuration.Top == false
            && configuration.Right == false
            && configuration.Bottom == true
            && configuration.Left == true)
        {
            prefab = TilePrefabCollection.TileLShapePrefab;
            rotation = 90f;
        }

        // L-Shape: Left & Top
        if (configuration.Top == true
            && configuration.Right == false
            && configuration.Bottom == false
            && configuration.Left == true)
        {
            prefab = TilePrefabCollection.TileLShapePrefab;
            rotation = 0f;
        }

        // T-Junction: Top & Right & Bottom
        if (configuration.Top == true
            && configuration.Right == true
            && configuration.Bottom == true
            && configuration.Left == false)
        {
            prefab = TilePrefabCollection.TileTJunctionPrefab;
            rotation = 270f;
        }

        // T-Junction: Right & Bottom & Left
        if (configuration.Top == false
            && configuration.Right == true
            && configuration.Bottom == true
            && configuration.Left == true)
        {
            prefab = TilePrefabCollection.TileTJunctionPrefab;
            rotation = 180f;
        }

        // T-Junction: Bottom & Left & Top
        if (configuration.Top == true
            && configuration.Right == false
            && configuration.Bottom == true
            && configuration.Left == true)
        {
            prefab = TilePrefabCollection.TileTJunctionPrefab;
            rotation = 90f;
        }

        // T-Junction: Left & Top & Right
        if (configuration.Top == true
            && configuration.Right == true
            && configuration.Bottom == false
            && configuration.Left == true)
        {
            prefab = TilePrefabCollection.TileTJunctionPrefab;
            rotation = 0f;
        }

        // Junction: Top & Right & Bottom & Left
        if (configuration.Top == true
            && configuration.Right == true
            && configuration.Bottom == true
            && configuration.Left == true)
        {
            prefab = TilePrefabCollection.TileJunctionPrefab;
            rotation = 0f;
        }

        // Entrance: Top
        if (configuration.Top == true
            && configuration.Entrance == true)
        {
            prefab = TilePrefabCollection.TileEntrancePrefab;
            rotation = 270f;
        }

        // Entrance: Right
        if (configuration.Right == true
            && configuration.Entrance == true)
        {
            prefab = TilePrefabCollection.TileEntrancePrefab;
            rotation = 180f;
        }

        // Entrance: Bottom
        if (configuration.Bottom == true
            && configuration.Entrance == true)
        {
            prefab = TilePrefabCollection.TileEntrancePrefab;
            rotation = 90f;
        }

        // Entrance: Left
        if (configuration.Left == true
            && configuration.Entrance == true)
        {
            prefab = TilePrefabCollection.TileEntrancePrefab;
            rotation = 0f;
        }

        // Exit: Top
        if (configuration.Top == true
            && configuration.Exit == true)
        {
            prefab = TilePrefabCollection.TileExitPrefab;
            rotation = 270f;
        }

        // Exit: Right
        if (configuration.Right == true
            && configuration.Exit == true)
        {
            prefab = TilePrefabCollection.TileExitPrefab;
            rotation = 180f;
        }

        // Exit: Bottom
        if (configuration.Bottom == true
            && configuration.Exit == true)
        {
            prefab = TilePrefabCollection.TileExitPrefab;
            rotation = 90f;
        }

        // Exit: Left
        if (configuration.Left == true
            && configuration.Exit == true)
        {
            prefab = TilePrefabCollection.TileExitPrefab;
            rotation = 0f;
        }

        GameObject tileVisualGameObject = Instantiate(prefab, Vector3.zero, Quaternion.Euler(0f, 0f, rotation));
        tileVisualGameObject.transform.SetParent(transform, false);

        VisualGameObject = tileVisualGameObject;
    }
}