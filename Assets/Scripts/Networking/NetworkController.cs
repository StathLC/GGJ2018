using System;
using System.Collections;
using System.Text;
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
        OnGameStarted?.Invoke();
        // TODO: Load additive scene -> gameplay scene.
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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

}
