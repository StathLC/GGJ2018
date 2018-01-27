using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TilePrefabCollectionScriptableObject TilePrefabCollection;
    public TileConfiguration TileConfiguration;

    private int xIndex;
    private int yIndex;



    public int XIndex
    {
        set { xIndex = value; }
        get { return xIndex; }
    }

    public int YIndex
    {
        set { yIndex = value; }
        get { return yIndex; }
    }



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



    private void PopulateTile(TileConfiguration configuration)
    {

    }
}