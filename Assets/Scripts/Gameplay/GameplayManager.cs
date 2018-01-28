using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Parameters")]
    public float CameraOffset;
    public PlayerIndex PlayerIndex;

    [Header("References")]
    public GridController Grid;
    public GameplayUIController UIController;
    public Transform CameraTransform;



    void Start()
    {

        if (PhotonNetwork.isMasterClient == true)
        {
            Grid.Initialize(CreateLevel1());
            StartCoroutine(InitializeAsMaster());
        }
    }

    void OnEnable()
    {
        NetworkController.Instance.OnAssignPlayerIndex += NetworkContoller_OnAssignPlayerIndex;
        NetworkController.Instance.OnAssignButtonFunctionalities += NetworkController_OnAssignButtonFunctionalities;
        NetworkController.Instance.OnBoardActionInitiated += NetworkController_OnBoardActionInitiated;
        NetworkController.Instance.OnLevelGenerated += Instance_OnLevelGenerated; ;
    }

    private void Instance_OnLevelGenerated(Level level)
    {
        Grid.Initialize(level);
    }

    void OnDisable()
    {
        NetworkController.Instance.OnAssignPlayerIndex -= NetworkContoller_OnAssignPlayerIndex;
        NetworkController.Instance.OnAssignButtonFunctionalities -= NetworkController_OnAssignButtonFunctionalities;
        NetworkController.Instance.OnLevelGenerated -= Instance_OnLevelGenerated; ;
    }



    public void SendBoardActionInitiated(ButtonFunctionalityType type)
    {
        NetworkController.Instance.SendBoardActionInitiated(type);
    }

    public void SendGameFinished()
    {
        NetworkController.Instance.SendCompletionMessage(true);
    }

    private Level CreateLevel1()
    {

        var x = UnityEngine.Random.Range(0, 3);
        TileConfiguration[] tileConfigurations;
        switch (x)
        {
            case 0:
                tileConfigurations = Levels.Configurations.Level1;
                break;
            case 1:
                tileConfigurations = Levels.Configurations.Level2;
                break;
            case 2:
                tileConfigurations = Levels.Configurations.Level3;
                break;
            default:
                tileConfigurations = Levels.Configurations.Level1;
                break;
                
        }
        Level level = new Level();
        level.TileConfigurations = tileConfigurations;

        NetworkController.Instance.SendMap(level);
        return level;
    }

    private void AssignPlayerIndex(PlayerIndex index)
    {
        PlayerIndex = index;

        switch (index)
        {
            case PlayerIndex.TopLeft:
                CameraTransform.position = new Vector3(-CameraOffset, CameraOffset, CameraTransform.position.z);
                break;

            case PlayerIndex.TopRight:
                CameraTransform.position = new Vector3(CameraOffset, CameraOffset, CameraTransform.position.z);
                break;

            case PlayerIndex.BottomRight:
                CameraTransform.position = new Vector3(CameraOffset, -CameraOffset, CameraTransform.position.z);
                break;

            case PlayerIndex.BottomLeft:
                CameraTransform.position = new Vector3(-CameraOffset, -CameraOffset, CameraTransform.position.z);
                break;
        }
    }

    private void AssignButtonFunctionalities(ButtonFunctionalityType[] types)
    {
        UIController.AssignLeftButtonFunctionality(types[0]);
        UIController.AssignRightButtonFunctionality(types[1]);
    }

    private IEnumerator InitializeAsMaster()
    {
        // Delay
        yield return new WaitForSeconds(1f);

        NetworkController.Instance.SendPlayerIndicesToPlayers();
        NetworkController.Instance.SendButtonFunctionalitiesToPlayers();
    }



    private void NetworkContoller_OnAssignPlayerIndex(PlayerIndex playerIndex)
    {
        AssignPlayerIndex(playerIndex);
    }

    private void NetworkController_OnAssignButtonFunctionalities(ButtonFunctionalityType[] types)
    {
        AssignButtonFunctionalities(types);
    }

    private void NetworkController_OnBoardActionInitiated(ButtonFunctionalityType type)
    {
        switch (type)
        {
            case ButtonFunctionalityType.MoveColumn0Down:
                Grid.MoveColumnDown(0);
                break;

            case ButtonFunctionalityType.MoveColumn0Up:
                Grid.MoveColumnUp(0);
                break;

            case ButtonFunctionalityType.MoveColumn1Down:
                Grid.MoveColumnDown(1);
                break;

            case ButtonFunctionalityType.MoveColumn1Up:
                Grid.MoveColumnUp(1);
                break;

            case ButtonFunctionalityType.MoveColumn2Down:
                Grid.MoveColumnDown(2);
                break;

            case ButtonFunctionalityType.MoveColumn2Up:
                Grid.MoveColumnUp(2);
                break;

            case ButtonFunctionalityType.MoveColumn3Down:
                Grid.MoveColumnDown(3);
                break;

            case ButtonFunctionalityType.MoveColumn3Up:
                Grid.MoveColumnUp(3);
                break;

            case ButtonFunctionalityType.MoveRow0Left:
                Grid.MoveRowLeft(0);
                break;

            case ButtonFunctionalityType.MoveRow0Right:
                Grid.MoveRowRight(0);
                break;

            case ButtonFunctionalityType.MoveRow1Left:
                Grid.MoveRowLeft(1);
                break;

            case ButtonFunctionalityType.MoveRow1Right:
                Grid.MoveRowRight(1);
                break;

            case ButtonFunctionalityType.MoveRow2Left:
                Grid.MoveRowLeft(2);
                break;

            case ButtonFunctionalityType.MoveRow2Right:
                Grid.MoveRowRight(2);
                break;

            case ButtonFunctionalityType.MoveRow3Left:
                Grid.MoveRowLeft(3);
                break;

            case ButtonFunctionalityType.MoveRow3Right:
                Grid.MoveRowRight(3);
                break;
        }
    }
}