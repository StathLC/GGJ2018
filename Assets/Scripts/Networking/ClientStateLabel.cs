using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ClientStateLabel : MonoBehaviour
{
    private TextMeshProUGUI _label;

    void OnEnable()
    {
        _label = GetComponent<TextMeshProUGUI>();
        _label.text = NetworkController.Instance.CurrentClientState.ToString();
        NetworkController.Instance.OnClientStateChanged += InstanceOnOnClientStateChanged;
    }
    void OnDisable()
    {
        NetworkController.Instance.OnClientStateChanged -= InstanceOnOnClientStateChanged;
    }

    private void InstanceOnOnClientStateChanged(object sender, ExitGames.Client.Photon.LoadBalancing.ClientState clientState)
    {
        _label.text = clientState.ToString();
    }
}
