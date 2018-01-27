using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ConnectionStateLabel : MonoBehaviour
{
    private TextMeshProUGUI _label;

    void OnEnable()
    {
        _label = GetComponent<TextMeshProUGUI>();
        _label.text = NetworkController.Instance.CurrentConnectionState.ToString();
        NetworkController.Instance.OnConnectionStateChanged += Instance_OnConnectionStateChanged;
    }
    void OnDisable()
    {
        NetworkController.Instance.OnConnectionStateChanged -= Instance_OnConnectionStateChanged;
    }

    private void Instance_OnConnectionStateChanged(object sender, ConnectionState e)
    {
        _label.text = e.ToString();
    }
}
