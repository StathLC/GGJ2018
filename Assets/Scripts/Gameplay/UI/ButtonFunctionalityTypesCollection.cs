using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctionalityTypesCollection
{
    private static ButtonFunctionalityType[] buttonFunctionalityTypesSetupA = new ButtonFunctionalityType[]
    {
        ButtonFunctionalityType.MoveColumn0Up,
        ButtonFunctionalityType.MoveColumn1Up,
        ButtonFunctionalityType.MoveColumn2Down,
        ButtonFunctionalityType.MoveColumn3Up,
        ButtonFunctionalityType.MoveRow0Right,
        ButtonFunctionalityType.MoveRow1Left,
        ButtonFunctionalityType.MoveRow2Right,
        ButtonFunctionalityType.MoveRow3Left,
    };

    private static ButtonFunctionalityType[] buttonFunctionalityTypesSetupB = new ButtonFunctionalityType[]
    {
        ButtonFunctionalityType.MoveColumn0Up,
        ButtonFunctionalityType.MoveColumn1Up,
        ButtonFunctionalityType.MoveColumn2Down,
        ButtonFunctionalityType.MoveColumn3Up,
        ButtonFunctionalityType.MoveRow0Right,
        ButtonFunctionalityType.MoveRow1Left,
        ButtonFunctionalityType.MoveRow2Left,
        ButtonFunctionalityType.MoveRow3Left,
    };

    private static ButtonFunctionalityType[] buttonFunctionalityTypesSetupC = new ButtonFunctionalityType[]
    {
        ButtonFunctionalityType.MoveColumn0Down,
        ButtonFunctionalityType.MoveColumn1Down,
        ButtonFunctionalityType.MoveColumn2Up,
        ButtonFunctionalityType.MoveColumn3Down,
        ButtonFunctionalityType.MoveRow0Right,
        ButtonFunctionalityType.MoveRow1Left,
        ButtonFunctionalityType.MoveRow2Right,
        ButtonFunctionalityType.MoveRow3Right,
    };

    private static ButtonFunctionalityType[] buttonFunctionalityTypesSetupD = new ButtonFunctionalityType[]
    {
        ButtonFunctionalityType.MoveColumn0Up,
        ButtonFunctionalityType.MoveColumn1Down,
        ButtonFunctionalityType.MoveColumn2Up,
        ButtonFunctionalityType.MoveColumn3Down,
        ButtonFunctionalityType.MoveRow0Right,
        ButtonFunctionalityType.MoveRow1Right,
        ButtonFunctionalityType.MoveRow2Right,
        ButtonFunctionalityType.MoveRow3Right,
    };



    public static ButtonFunctionalityType[] GetRandomButtonFunctionalityTypesSetup()
    {
        ButtonFunctionalityType[] buttonFunctionalityTypes = null;

        int randomSetupIndex = Random.Range(0, 4);
        switch (randomSetupIndex)
        {
            case 0:
                buttonFunctionalityTypes = buttonFunctionalityTypesSetupA;
                break;

            case 1:
                buttonFunctionalityTypes = buttonFunctionalityTypesSetupB;
                break;

            case 2:
                buttonFunctionalityTypes = buttonFunctionalityTypesSetupC;
                break;

            case 3:
                buttonFunctionalityTypes = buttonFunctionalityTypesSetupD;
                break;
        }

        return buttonFunctionalityTypes;
    }
}