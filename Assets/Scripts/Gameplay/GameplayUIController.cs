using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    public GridController Grid;

    public void OnLeftButtonClicked()
    {
        Grid.MoveRowLeft(0);
    }

    public void OnRightButtonClicked()
    {
        Grid.MoveRowRight(1);
    }

    public void OnRestartButtonClicked()
    {

    }
}