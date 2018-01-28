using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public NetworkController NetworkController;
    public GameObject CanvasGameObject;
    public GameObject CameraGameObject;

    void OnEnable()
    {
        NetworkController.OnGameStarted += NetworkController_OnGameStarted;
    }

    void OnDisable()
    {
        NetworkController.OnGameStarted += NetworkController_OnGameStarted;
    }

    private void NetworkController_OnGameStarted()
    {
        CanvasGameObject.SetActive(false);
        CameraGameObject.SetActive(false);

        SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
    }
}