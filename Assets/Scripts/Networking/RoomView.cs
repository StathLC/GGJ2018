using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _roomName;
    [SerializeField] private TextMeshProUGUI _usersCount;
    [SerializeField] private TextMeshProUGUI _users;
    [SerializeField] private Button _startGameeButton;
    private Room _room;
    private int count;

    void Awake()
    {
        NetworkController.Instance.OnRoomJoined += Initialize;
        NetworkController.Instance.OnRoomLeft += Instance_OnRoomLeft;
        gameObject.SetActive(false);
    }

    private void Instance_OnRoomLeft()
    {
        gameObject.SetActive(false);
    }

    private void Initialize(Room room)
    {
        _room = room;

        _roomName.text = room.Name;
        OnPlayersChanged();
        gameObject.SetActive(true);
    }

    private void OnPlayersChanged()
    {
        _usersCount.text = $"{_room.PlayerCount} / {_room.MaxPlayers}";
        
        _startGameeButton.gameObject.SetActive(PhotonNetwork.isMasterClient && _room.PlayerCount == _room.MaxPlayers);

        StringBuilder builder = new StringBuilder();
        foreach (var photonPlayer in PhotonNetwork.playerList)
        {
            builder.AppendLine(photonPlayer.NickName);
        }
        _users.text = builder.ToString();
        count = PhotonNetwork.playerList.Length;
    }

    void Update()
    {
        if (count != PhotonNetwork.playerList.Length)
        {
            OnPlayersChanged();           
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void StartGame()
    {
        
    }

}
