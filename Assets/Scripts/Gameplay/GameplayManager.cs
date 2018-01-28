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
            InitializeAsMaster();
        }
    }

    void OnEnable()
    {
        PhotonNetwork.OnEventCall += PhotonNetwork_OnEventCall;
    }

    void OnDisable()
    {
        PhotonNetwork.OnEventCall -= PhotonNetwork_OnEventCall;
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

    private void AssignPlayerIndexForCamera(PlayerIndex index)
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

    private void InitializeAsMaster()
    {
        // Player Ids.
        List<int> playerIds = new List<int>();
        foreach (PhotonPlayer photonPlayer in PhotonNetwork.playerList)
        {
            playerIds.Add(photonPlayer.ID);
        }

        // Create level.
        RaiseEventOptions createLevelOptions = RaiseEventOptions.Default;
        createLevelOptions.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(0, CreateLevel1(), true, createLevelOptions);

        // Assign player indices.
        RaiseEventOptions assignPlayerIndicesOptions = new RaiseEventOptions();
        assignPlayerIndicesOptions.TargetActors = playerIds.ToArray();

        PlayerIndex[] playerIndices = new PlayerIndex[]
        {
            PlayerIndex.TopLeft,
            PlayerIndex.TopRight,
            PlayerIndex.BottomRight,
            PlayerIndex.BottomLeft
        };

        ArrayShuffler.Shuffle(playerIndices);

        Dictionary<int, PlayerIndex> assignPlayerIndicesParameters = new Dictionary<int, PlayerIndex>();
        assignPlayerIndicesParameters.Add(playerIds[0], playerIndices[0]);
        assignPlayerIndicesParameters.Add(playerIds[1], playerIndices[1]);
        assignPlayerIndicesParameters.Add(playerIds[2], playerIndices[2]);
        assignPlayerIndicesParameters.Add(playerIds[3], playerIndices[3]);
        PhotonNetwork.RaiseEvent(1, assignPlayerIndicesParameters, true, assignPlayerIndicesOptions);

        // Assign button functionalities.
        RaiseEventOptions assignButtonFunctionalitiesOptions = new RaiseEventOptions();
        assignButtonFunctionalitiesOptions.TargetActors = playerIds.ToArray();

        ButtonFunctionalityType[] buttonFunctionalityTypes = ButtonFunctionalityTypesCollection.GetRandomButtonFunctionalityTypesSetup();

        ArrayShuffler.Shuffle(buttonFunctionalityTypes);

        Dictionary<int, ButtonFunctionalityType[]> assignButtonFunctionalitiesParameters = new Dictionary<int, ButtonFunctionalityType[]>();
        assignButtonFunctionalitiesParameters.Add(playerIds[0], new ButtonFunctionalityType[]
        {
            buttonFunctionalityTypes[0],
            buttonFunctionalityTypes[1]
        });
        assignButtonFunctionalitiesParameters.Add(playerIds[1], new ButtonFunctionalityType[]
        {
            buttonFunctionalityTypes[2],
            buttonFunctionalityTypes[3]
        });
        assignButtonFunctionalitiesParameters.Add(playerIds[2], new ButtonFunctionalityType[]
        {
            buttonFunctionalityTypes[4],
            buttonFunctionalityTypes[5]
        });
        assignButtonFunctionalitiesParameters.Add(playerIds[3], new ButtonFunctionalityType[]
        {
            buttonFunctionalityTypes[6],
            buttonFunctionalityTypes[7]
        });
        PhotonNetwork.RaiseEvent(2, assignButtonFunctionalitiesParameters, true, assignButtonFunctionalitiesOptions);
    }

    private void PhotonNetwork_OnEventCall(byte eventCode, object content, int senderId)
    {
        // Create level.
        if (eventCode == 0)
        {
            PhotonPlayer sender = PhotonPlayer.Find(senderId);  // who sent this?
            Debug.Log("Create level event received, sender is: " + sender.NickName + " master?: " + sender.IsMasterClient);

            Level level = content as Level;
            Grid.Initialize(level);
        }

        // Assign player indices.
        else if (eventCode == 1)
        {
            PhotonPlayer sender = PhotonPlayer.Find(senderId);  // who sent this?
            Debug.Log("Assign player index event received, sender is: " + sender.NickName + " master?: " + sender.IsMasterClient);

            Dictionary<int, PlayerIndex> objDict = content as Dictionary<int, PlayerIndex>;
            PlayerIndex playerIndex = objDict[PhotonNetwork.player.ID];

            AssignPlayerIndexForCamera(playerIndex);
        }

        // Assign button functionalities.
        else if (eventCode == 2)
        {
            PhotonPlayer sender = PhotonPlayer.Find(senderId);  // who sent this?
            Debug.Log("Assign button functionalities event received, sender is: " + sender.NickName + " master?: " + sender.IsMasterClient);

            Dictionary<int, ButtonFunctionalityType[]> objDict = content as Dictionary<int, ButtonFunctionalityType[]>;
            AssignButtonFunctionalities(objDict[PhotonNetwork.player.ID]);
        }
    }
}