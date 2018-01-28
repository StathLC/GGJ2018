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
        Grid.Initialize(CreateLevel1());
        //UIController.AssignLeftButtonFunctionality(ButtonFunctionalityType.MoveColumn3Up);
        //UIController.AssignRightButtonFunctionality(ButtonFunctionalityType.MoveRow2Left);
        //AssignPlayerIndexForCamera(PlayerIndex);

        if (PhotonNetwork.isMasterClient == true)
        {
            StartCoroutine(InitializeAsMaster());
        }
    }

    void OnEnable()
    {
        PhotonNetwork.OnEventCall += PhotonNetwork_OnEventCall;

        NetworkController.Instance.OnAssignPlayerIndex += NetworkContoller_OnAssignPlayerIndex;
        NetworkController.Instance.OnAssignButtonFunctionalities += NetworkController_OnAssignButtonFunctionalities;
    }

    void OnDisable()
    {
        PhotonNetwork.OnEventCall -= PhotonNetwork_OnEventCall;

        NetworkController.Instance.OnAssignPlayerIndex -= NetworkContoller_OnAssignPlayerIndex;
        NetworkController.Instance.OnAssignButtonFunctionalities -= NetworkController_OnAssignButtonFunctionalities;
    }



    private Level CreateLevel1()
    {
        List<TileConfiguration> tileConfigurations = new List<TileConfiguration>()
        {
            new TileConfiguration(top:false,bottom:false,right:true,left:false,entrance:true,exit:false),//[0,0]
            new TileConfiguration(top:false,bottom:true,right:false,left:true,entrance:false,exit:false),//[0,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,2]
            new TileConfiguration(top:false,bottom:true,right:false,left:false,entrance:false,exit:true),//[0,3]

            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,2]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,3]

            new TileConfiguration(top:true,bottom:true,right:true,left:true,entrance:false,exit:false),//[2,0]
            new TileConfiguration(top:true,bottom:false,right:false,left:true,entrance:false,exit:false),//[2,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,2]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[2,3]

            new TileConfiguration(top:true,bottom:false,right:true,left:false,entrance:false,exit:false),//[3,0]
            new TileConfiguration(top:false,bottom:false,right:true,left:true,entrance:false,exit:false),//[3,1]
            new TileConfiguration(top:false,bottom:false,right:true,left:true,entrance:false,exit:false),//[3,2]
            new TileConfiguration(top:true,bottom:false,right:true,left:true,entrance:false,exit:false),//[3,3]
        };

        Level level = new Level();
        level.TileConfigurations = tileConfigurations.ToArray();

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
        yield return new WaitForSeconds(3f);

        NetworkController.Instance.SendPlayerIndicesToPlayers();
        NetworkController.Instance.SendButtonFunctionalitiesToPlayers();
    }



    private void PhotonNetwork_OnEventCall(byte eventCode, object content, int senderId)
    {
        // Assign player indices.
        if (eventCode == 1)
        {
            PhotonPlayer sender = PhotonPlayer.Find(senderId);  // who sent this?
            Debug.Log("Assign player index event received, sender is: " + sender.NickName + " master?: " + sender.IsMasterClient);

            Dictionary<int, PlayerIndex> objDict = content as Dictionary<int, PlayerIndex>;
            PlayerIndex playerIndex = objDict[PhotonNetwork.player.ID];

            AssignPlayerIndex(playerIndex);
        }

        // Assign button functionalities.
        if (eventCode == 2)
        {
            PhotonPlayer sender = PhotonPlayer.Find(senderId);  // who sent this?
            Debug.Log("Assign button functionalities event received, sender is: " + sender.NickName + " master?: " + sender.IsMasterClient);

            Dictionary<int, ButtonFunctionalityType[]> objDict = content as Dictionary<int, ButtonFunctionalityType[]>;
            AssignButtonFunctionalities(objDict[PhotonNetwork.player.ID]);
        }
    }

    private void NetworkContoller_OnAssignPlayerIndex(PlayerIndex playerIndex)
    {
        AssignPlayerIndex(playerIndex);
    }

    private void NetworkController_OnAssignButtonFunctionalities(ButtonFunctionalityType[] types)
    {
        AssignButtonFunctionalities(types);
    }
}