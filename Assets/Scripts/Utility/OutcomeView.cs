using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutcomeView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _label;

    private void Awake()
    {
        NetworkController.Instance.OnGameCompleted += Instance_OnGameCompleted;
        gameObject.SetActive(false);            
    }

    private void Instance_OnGameCompleted(bool win)
    {
        _label.text = win ? "VICTORY!" : "DEFEAT!";
        gameObject.SetActive(true);
    }
}
