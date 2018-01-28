using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public NetworkController NetworkController;
    public GameObject CanvasGameObject;
    public GameObject CameraGameObject;
    public GameObject BackgroundGameObject;

    void OnEnable()
    {
        NetworkController.OnGameStarted += NetworkController_OnGameStarted;
        NetworkController.OnGameCompleted += NetworkController_OnGameCompleted;
    }

    void OnDisable()
    {
        NetworkController.OnGameStarted -= NetworkController_OnGameStarted;
        NetworkController.OnGameCompleted -= NetworkController_OnGameCompleted;
    }

    private void NetworkController_OnGameCompleted(bool win)
    {
        CanvasGameObject.SetActive(false);
        CameraGameObject.SetActive(true);
        BackgroundGameObject.SetActive(true);

        var scene = SceneManager.GetSceneByName("Gameplay");
        foreach (var rootGameObject in scene.GetRootGameObjects())
        {
            Destroy(rootGameObject);
        }
    }

    private void NetworkController_OnGameStarted()
    {
        CanvasGameObject.SetActive(false);
        CameraGameObject.SetActive(false);
        BackgroundGameObject.SetActive(false);

        SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
    }
    
}