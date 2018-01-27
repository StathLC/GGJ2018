using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class LobbyView : Photon.PunBehaviour
{

    [SerializeField] private TMP_InputField _roomNameLabel;
    [SerializeField] private TextMeshProUGUI _roomCounts;
    [SerializeField] private GameObject roomObjectPrefab;
    [SerializeField] private RectTransform _roomContent;
    private List<RoomObject> _rooms = new List<RoomObject>();
    


    void Awake()
    {
        NetworkController.Instance.OnLobbyJoined += () => { gameObject.SetActive(true); };
        NetworkController.Instance.OnLobbyLeft += () => { gameObject.SetActive(false); };
        gameObject.SetActive(false);
    }

    internal void Join(RoomInfo room)
    {
        NetworkController.Instance.JoinRoom(room.Name);
    }

    void OnEnable()
    {
        StartCoroutine(GetRooms());
    }

    private IEnumerator GetRooms()
    {
        if (!PhotonNetwork.connected)
            yield break;
        yield return new WaitForSeconds(.5f);
        RefreshList();
    }
    
    public void Join()
    {
        NetworkController.Instance.JoinRoom(_roomNameLabel.text);
    }

    public void Create()
    {
        NetworkController.Instance.CreateRoom(_roomNameLabel.text);
    }

    void Update()
    {
        if (_rooms.Count != PhotonNetwork.countOfRooms)
        {
            RefreshList();
        }
    }

    public void RefreshList()
    {
        SpawnRooms(NetworkController.Instance.GetRooms());
    }

    public void Disconnect()
    {
        NetworkController.Instance.Disconnect();
    }


    private void SpawnRooms(RoomInfo[] rooms)
    {
        _rooms.ForEach(x => Destroy(x.gameObject));
        _roomCounts.text = $"{PhotonNetwork.countOfRooms} rooms";
        foreach (var roomInfo in rooms)
        {
            var prefab = GameObject.Instantiate(roomObjectPrefab);
            var component = prefab.GetComponent<RoomObject>();
            prefab.transform.SetParent(_roomContent);
            component.Initialize(this, roomInfo);
        }
        
    }

}
