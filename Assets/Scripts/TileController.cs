using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public void SetPosition(int x, int y, float coefficient)
    {
        transform.localPosition = new Vector3(x * coefficient, -y * coefficient);
    }
}