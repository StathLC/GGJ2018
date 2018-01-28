using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    public GridController Grid;

    private Action LeftButtonClickAction;
    private Action RightButtonClickAction;



    public void AssignLeftButtonFunctionality(ButtonFunctionalityType type)
    {
        switch (type)
        {
            case ButtonFunctionalityType.MoveColumn0Down:
                LeftButtonClickAction = MoveColumn0Down;
                break;

            case ButtonFunctionalityType.MoveColumn0Up:
                LeftButtonClickAction = MoveColumn0Up;
                break;

            case ButtonFunctionalityType.MoveColumn1Down:
                LeftButtonClickAction = MoveColumn1Down;
                break;

            case ButtonFunctionalityType.MoveColumn1Up:
                LeftButtonClickAction = MoveColumn1Up;
                break;

            case ButtonFunctionalityType.MoveColumn2Down:
                LeftButtonClickAction = MoveColumn2Down;
                break;

            case ButtonFunctionalityType.MoveColumn2Up:
                LeftButtonClickAction = MoveColumn2Up;
                break;

            case ButtonFunctionalityType.MoveColumn3Down:
                LeftButtonClickAction = MoveColumn3Down;
                break;

            case ButtonFunctionalityType.MoveColumn3Up:
                LeftButtonClickAction = MoveColumn3Up;
                break;

            case ButtonFunctionalityType.MoveRow0Left:
                LeftButtonClickAction = MoveRow0Left;
                break;

            case ButtonFunctionalityType.MoveRow0Right:
                LeftButtonClickAction = MoveRow0Right;
                break;

            case ButtonFunctionalityType.MoveRow1Left:
                LeftButtonClickAction = MoveRow1Left;
                break;

            case ButtonFunctionalityType.MoveRow1Right:
                LeftButtonClickAction = MoveRow1Right;
                break;

            case ButtonFunctionalityType.MoveRow2Left:
                LeftButtonClickAction = MoveRow2Left;
                break;

            case ButtonFunctionalityType.MoveRow2Right:
                LeftButtonClickAction = MoveRow2Right;
                break;

            case ButtonFunctionalityType.MoveRow3Left:
                LeftButtonClickAction = MoveRow3Left;
                break;

            case ButtonFunctionalityType.MoveRow3Right:
                LeftButtonClickAction = MoveRow3Right;
                break;
        }
    }

    public void AssignRightButtonFunctionality(ButtonFunctionalityType type)
    {
        switch (type)
        {
            case ButtonFunctionalityType.MoveColumn0Down:
                RightButtonClickAction = MoveColumn0Down;
                break;

            case ButtonFunctionalityType.MoveColumn0Up:
                RightButtonClickAction = MoveColumn0Up;
                break;

            case ButtonFunctionalityType.MoveColumn1Down:
                RightButtonClickAction = MoveColumn1Down;
                break;

            case ButtonFunctionalityType.MoveColumn1Up:
                RightButtonClickAction = MoveColumn1Up;
                break;

            case ButtonFunctionalityType.MoveColumn2Down:
                RightButtonClickAction = MoveColumn2Down;
                break;

            case ButtonFunctionalityType.MoveColumn2Up:
                RightButtonClickAction = MoveColumn2Up;
                break;

            case ButtonFunctionalityType.MoveColumn3Down:
                RightButtonClickAction = MoveColumn3Down;
                break;

            case ButtonFunctionalityType.MoveColumn3Up:
                RightButtonClickAction = MoveColumn3Up;
                break;

            case ButtonFunctionalityType.MoveRow0Left:
                RightButtonClickAction = MoveRow0Left;
                break;

            case ButtonFunctionalityType.MoveRow0Right:
                RightButtonClickAction = MoveRow0Right;
                break;

            case ButtonFunctionalityType.MoveRow1Left:
                RightButtonClickAction = MoveRow1Left;
                break;

            case ButtonFunctionalityType.MoveRow1Right:
                RightButtonClickAction = MoveRow1Right;
                break;

            case ButtonFunctionalityType.MoveRow2Left:
                RightButtonClickAction = MoveRow2Left;
                break;

            case ButtonFunctionalityType.MoveRow2Right:
                RightButtonClickAction = MoveRow2Right;
                break;

            case ButtonFunctionalityType.MoveRow3Left:
                RightButtonClickAction = MoveRow3Left;
                break;

            case ButtonFunctionalityType.MoveRow3Right:
                RightButtonClickAction = MoveRow3Right;
                break;
        }
    }

    public void OnLeftButtonClicked()
    {
        LeftButtonClickAction();
    }

    public void OnRightButtonClicked()
    {
        RightButtonClickAction();
    }

    public void OnTalkButtonClicked()
    {
        Debug.Log("TALK");
    }

    public void OnExitGameButtonClicked()
    {
        Debug.Log("EXIT GAME");
    }



    private void MoveColumn0Up()
    {
        Grid.MoveColumnUp(0);
    }

    private void MoveColumn0Down()
    {
        Grid.MoveColumnDown(0);
    }

    private void MoveColumn1Up()
    {
        Grid.MoveColumnUp(1);
    }

    private void MoveColumn1Down()
    {
        Grid.MoveColumnDown(1);
    }

    private void MoveColumn2Up()
    {
        Grid.MoveColumnUp(2);
    }

    private void MoveColumn2Down()
    {
        Grid.MoveColumnDown(2);
    }

    private void MoveColumn3Up()
    {
        Grid.MoveColumnUp(3);
    }

    private void MoveColumn3Down()
    {
        Grid.MoveColumnDown(3);
    }

    private void MoveRow0Right()
    {
        Grid.MoveRowRight(0);
    }

    private void MoveRow0Left()
    {
        Grid.MoveRowLeft(0);
    }

    private void MoveRow1Right()
    {
        Grid.MoveRowRight(1);
    }

    private void MoveRow1Left()
    {
        Grid.MoveRowLeft(1);
    }

    private void MoveRow2Right()
    {
        Grid.MoveRowRight(2);
    }

    private void MoveRow2Left()
    {
        Grid.MoveRowLeft(2);
    }

    private void MoveRow3Right()
    {
        Grid.MoveRowRight(3);
    }

    private void MoveRow3Left()
    {
        Grid.MoveRowLeft(3);
    }
}