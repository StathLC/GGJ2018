using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomObject : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI RoomName;
    private RoomInfo _room;
    private Action onClick;

    private int count;
    private int max;

    public void Initialize(LobbyView lobby, RoomInfo room)
    {
        _room = room;
        onClick = () => { lobby.Join(room); };
        RoomName.text = $"{room.Name} : {room.PlayerCount}/{room.MaxPlayers}";
    }

    void Update()
    {
        if (max != _room.MaxPlayers || count != _room.PlayerCount)
        {
            RoomName.text = $"{_room.Name} : {_room.PlayerCount}/{_room.MaxPlayers}";
            count = _room.PlayerCount;
            max = _room.MaxPlayers;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        onClick.Invoke();
    }
}
