using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class NetworkController : Photon.PunBehaviour
{
    public int MaxPlayers = 4;
    public event EventHandler<ConnectionState> OnConnectionStateChanged;
    public event EventHandler<ExitGames.Client.Photon.LoadBalancing.ClientState> OnClientStateChanged;
    public event RoomJoined OnRoomJoined;
    public event RoomLeft OnRoomLeft;
    public event LobbyJoined OnLobbyJoined;
    public event LobbyLeft OnLobbyLeft;
    public event GameStarted OnGameStarted;
    public event GameCompleted OnGameCompleted;
    public event MasterMovement OnMasterMovement;
    public event PlayerMovement OnPlayerMovement;
    public Action<PlayerIndex> OnAssignPlayerIndex;
    public Action<ButtonFunctionalityType[]> OnAssignButtonFunctionalities;
    public Action<ButtonFunctionalityType> OnBoardActionInitiated;


    public static NetworkController Instance { get; private set; }
    public ConnectionState CurrentConnectionState { get; private set; }
    public ExitGames.Client.Photon.LoadBalancing.ClientState CurrentClientState { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Instance = this;
            PhotonVoiceNetwork.Client.OnStateChangeAction += OnVoiceClientStateChanged;
        }
    }

    private void OnVoiceClientStateChanged(ExitGames.Client.Photon.LoadBalancing.ClientState obj)
    {
        switch (obj)
        {
            case ExitGames.Client.Photon.LoadBalancing.ClientState.PeerCreated:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Authenticating:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Authenticated:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.JoinedLobby:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.DisconnectingFromMasterserver:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.ConnectingToGameserver:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.ConnectedToGameserver:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Joining:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Joined:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Leaving:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.DisconnectingFromGameserver:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.ConnectingToMasterserver:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Disconnecting:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.Disconnected:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.ConnectedToMasterserver:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.ConnectingToNameServer:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.ConnectedToNameServer:
                break;
            case ExitGames.Client.Photon.LoadBalancing.ClientState.DisconnectingFromNameServer:
                break;
        }

        CurrentClientState = obj;
        OnClientStateChanged?.Invoke(this, obj);
    }


    public override void OnJoinedLobby()
    {
        OnLobbyJoined?.Invoke();
    }
    public override void OnLeftLobby()
    {
        OnLobbyLeft?.Invoke();
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        base.OnPhotonPlayerConnected(newPlayer);
        Debug.Log(newPlayer.NickName);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        OnRoomJoined?.Invoke(PhotonNetwork.room);
    }

    public override void OnLeftRoom()
    {
        OnRoomLeft?.Invoke();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("ggj2018");
    }

    public void SetNick(string nick)
    {
        PhotonNetwork.playerName = nick;
    }

    public void CreateRoom(string name)
    {
        if (PhotonNetwork.JoinOrCreateRoom(name, new RoomOptions()
        {
            MaxPlayers = (byte)this.MaxPlayers,
            CleanupCacheOnLeave = true,
            IsVisible = true
        }, new TypedLobby()))
        {

        }
    }

    public void JoinRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveLobby();
    }

    public void StartGame()
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("RecievedStartGame", PhotonTargets.All);
        }
    }

    public void SendPlayerIndicesToPlayers()
    {
        if (PhotonNetwork.isMasterClient == false)
        {
            return;
        }

        // Player Ids.
        List<int> playerIds = new List<int>();
        foreach (PhotonPlayer photonPlayer in PhotonNetwork.playerList)
        {
            playerIds.Add(photonPlayer.ID);
        }

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

        Dictionary<int, int> assignPlayerIndicesParameters = new Dictionary<int, int>();
        assignPlayerIndicesParameters.Add(playerIds[0], (int)playerIndices[0]);
        assignPlayerIndicesParameters.Add(playerIds[1], (int)playerIndices[1]);
        if (playerIds.Count > 2) assignPlayerIndicesParameters.Add(playerIds[2], (int)playerIndices[2]);
        if (playerIds.Count > 3) assignPlayerIndicesParameters.Add(playerIds[3], (int)playerIndices[3]);

        photonView.RPC("ReceivedAssignPlayerIndices", PhotonTargets.All, assignPlayerIndicesParameters);
        //PhotonNetwork.RaiseEvent(1, assignPlayerIndicesParameters, true, assignPlayerIndicesOptions);
    }

    public void SendButtonFunctionalitiesToPlayers()
    {
        if (PhotonNetwork.isMasterClient == false)
        {
            return;
        }

        // Player Ids.
        List<int> playerIds = new List<int>();
        foreach (PhotonPlayer photonPlayer in PhotonNetwork.playerList)
        {
            playerIds.Add(photonPlayer.ID);
        }

        // Assign button functionalities.
        RaiseEventOptions assignButtonFunctionalitiesOptions = new RaiseEventOptions();
        assignButtonFunctionalitiesOptions.TargetActors = playerIds.ToArray();

        ButtonFunctionalityType[] buttonFunctionalityTypes = ButtonFunctionalityTypesCollection.GetRandomButtonFunctionalityTypesSetup();

        ArrayShuffler.Shuffle(buttonFunctionalityTypes);

        Dictionary<int, int[]> assignButtonFunctionalitiesParameters = new Dictionary<int, int[]>();
        assignButtonFunctionalitiesParameters.Add(playerIds[0], new int[]
        {
            (int)buttonFunctionalityTypes[0],
            (int)buttonFunctionalityTypes[1]
        });
        assignButtonFunctionalitiesParameters.Add(playerIds[1], new int[]
        {
            (int)buttonFunctionalityTypes[2],
            (int)buttonFunctionalityTypes[3]
        });
        if (playerIds.Count > 2)
        {
            assignButtonFunctionalitiesParameters.Add(playerIds[2], new int[]
            {
                (int)buttonFunctionalityTypes[4],
                (int)buttonFunctionalityTypes[5]
            });
        }
        if (playerIds.Count > 3)
        {
            assignButtonFunctionalitiesParameters.Add(playerIds[3], new int[]
            {
                (int)buttonFunctionalityTypes[6],
                (int)buttonFunctionalityTypes[7]
            });
        }

        photonView.RPC("ReceivedAssignButtonFunctionalities", PhotonTargets.All, JsonConvert.SerializeObject(assignButtonFunctionalitiesParameters));
        //PhotonNetwork.RaiseEvent(2, assignButtonFunctionalitiesParameters, true, assignButtonFunctionalitiesOptions);
    }

    public void SendBoardActionInitiated(ButtonFunctionalityType type)
    {
        photonView.RPC("ReceivedBoardActionInitiated", PhotonTargets.Others, (int)type);
    }

    public void SendPlayerMovementToMaster(EInput button)
    {
        photonView.RPC("InputReceived", PhotonTargets.MasterClient, photonView.ownerId, (int)button);
    }

    public void SendPlayerMovementToPlayers(int row, int col, int direction)
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("InputReceived", PhotonTargets.All, row, col, direction);
        }
    }

    public void SendCompletionMessage(bool win)
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("RecievedCompletionMessage", PhotonTargets.All, win);
        }
    }

    [PunRPC]
    private void RecievedStartGame()
    {
        Debug.Log("NetworkController: ReceivedStartGame");
        OnGameStarted?.Invoke();
    }

    [PunRPC]
    private void ReceivedAssignPlayerIndices(object content)
    {
        Dictionary<int, int> objDict = content as Dictionary<int, int>;
        PlayerIndex playerIndex = (PlayerIndex)objDict[PhotonNetwork.player.ID];

        OnAssignPlayerIndex(playerIndex);
    }

    [PunRPC]
    private void ReceivedAssignButtonFunctionalities(string content)
    {
        var dic = JsonConvert.DeserializeObject<Dictionary<int, int[]>>(content);
        ButtonFunctionalityType[] types = new ButtonFunctionalityType[2];
        foreach (KeyValuePair<int, int[]> kvp in dic)
        {
            if (kvp.Key == PhotonNetwork.player.ID)
            {
                types[0] = (ButtonFunctionalityType)kvp.Value[0];
                types[1] = (ButtonFunctionalityType)kvp.Value[1];
            }
        }

        //OnAssignButtonFunctionalities(objDict[PhotonNetwork.player.ID]);
        OnAssignButtonFunctionalities(types);
    }

    [PunRPC]
    private void ReceivedBoardActionInitiated(int type)
    {
        OnBoardActionInitiated?.Invoke((ButtonFunctionalityType)type);
    }

    [PunRPC]
    private void RecievedCompletionMessage(bool win)
    {
        Debug.Log("NetworkController: ReceivedCompletionMessage: " + win);
        OnGameCompleted?.Invoke(win);
    }

    [PunRPC]
    private void InputReceived(int player, int button)
    {
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("NetworkController: MASTER InputReceived: " + player + " " + button);
            OnMasterMovement?.Invoke(player, button);
        }
    }

    [PunRPC]
    private void InputReceived(int row, int col, int direction)
    {
        Debug.Log("NetworkController: InputReceived: " + row + " " + col + " " + direction);
        OnPlayerMovement?.Invoke(row, col, direction);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnGameCompleted?.Invoke(true);
            //Application.Quit();
        }
        if (PhotonNetwork.connectionState != CurrentConnectionState)
        {
            CurrentConnectionState = PhotonNetwork.connectionState;

            switch (CurrentConnectionState)
            {
                case ConnectionState.Disconnected:
                    break;
                case ConnectionState.Connecting:
                    break;
                case ConnectionState.Connected:
                    break;
                case ConnectionState.Disconnecting:
                    break;
                case ConnectionState.InitializingApplication:
                    break;
            }

            OnConnectionStateChanged?.Invoke(this, CurrentConnectionState);
        }


    }


    public RoomInfo[] GetRooms()
    {
        return PhotonNetwork.GetRoomList();
    }


    public delegate void RoomJoined(Room room);
    public delegate void RoomLeft();
    public delegate void LobbyJoined();
    public delegate void LobbyLeft();
    public delegate void GameStarted();
    public delegate void GameCompleted(bool win);
    public delegate void MasterMovement(int player, int button);
    public delegate void PlayerMovement(int row, int col, int direction);


}
