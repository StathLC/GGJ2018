using UnityEngine;

public class PlayerConnect : MonoBehaviour {

    void Awake()
    {
        NetworkController.Instance.OnConnectionStateChanged += Instance_OnConnectionStateChanged;

        Instance_OnConnectionStateChanged(this, NetworkController.Instance.CurrentConnectionState);
    }

    private void Instance_OnConnectionStateChanged(object sender, ConnectionState e)
    {
        switch (e)
        {
            case ConnectionState.Disconnected:
                gameObject.SetActive(true);
                break;
            case ConnectionState.Connecting:
                gameObject.SetActive(false);
                break;
            case ConnectionState.Connected:
                gameObject.SetActive(false);
                break;
            case ConnectionState.Disconnecting:
                gameObject.SetActive(false);
                break;
            case ConnectionState.InitializingApplication:
                gameObject.SetActive(false);
                break;
            default:
                gameObject.SetActive(false);
                break;
                
        }
    }

    public void SetPlayerNick(string nick)
    {
        NetworkController.Instance.SetNick(nick);
    }

    public void Connect()
    {
        NetworkController.Instance.Connect();
    }

}
