using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Player : Photon.PunBehaviour
{
    [SerializeField]private TextMeshProUGUI infoLabel;
    
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("joined lobby");
        SpawnRooms(PhotonNetwork.GetRoomList());
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
        base.OnJoinedRoom();

        StringBuilder builder = new StringBuilder("joined room");
        var room = PhotonNetwork.room;
        builder.AppendLine($"{room.Name} {room.PlayerCount}");
        
        infoLabel.text = builder.ToString();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("ggj2018");
    }

    private void SpawnRooms(RoomInfo[] rooms)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var roomInfo in rooms)
        {
            builder.AppendLine($"{roomInfo.Name} {roomInfo.PlayerCount}");
        }
        infoLabel.text = builder.ToString();
    }

    public void SetNick(string nick)
    {
        PhotonNetwork.playerName = nick;
    }

    public void CreateRoom(string name)
    {
        if (PhotonNetwork.JoinOrCreateRoom(name, new RoomOptions()
        {
            MaxPlayers = 4,
            CleanupCacheOnLeave = true
        }, new TypedLobby()))
        {
        }
    }

    private IEnumerable CallNextFrame(Action action)
    {
        yield return new WaitForEndOfFrame();

        action?.Invoke();
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
    
}
