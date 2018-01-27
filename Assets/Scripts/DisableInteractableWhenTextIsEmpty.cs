using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class DisableInteractableWhenTextIsEmpty : MonoBehaviour
{
    private Selectable _selectable;
    [SerializeField] private TMP_InputField _field;

    void Awake()
    {
        _selectable = GetComponent<Selectable>();
    }

    void Update()
    {
        _selectable.interactable = !string.IsNullOrWhiteSpace(_field.text);
    }
}
