using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public NetworkController NetworkController;
    public GameObject CanvasGameObject;
    public GameObject BackgroundGameObject;
    public GameObject CameraGameObject;
    public GameObject EventSystemGameObject;
    public GameObject DirectionalLightGameObject;

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
        BackgroundGameObject.SetActive(false);
        CameraGameObject.SetActive(false);
        EventSystemGameObject.SetActive(false);
        DirectionalLightGameObject.SetActive(false);

        SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
    }
}