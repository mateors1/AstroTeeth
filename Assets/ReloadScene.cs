using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    GameControllerActions gameController;
    
    // Call this method to refresh the webpage or reload the scene
    public void RefreshWebPageOrReloadScene()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // WebGL platform, reload the webpage
            Application.ExternalCall("location.reload");
#else
        // Not WebGL platform, reload the scene
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
#endif
    }

 

    void OnEnable()
    {
        gameController = new GameControllerActions();
        gameController.Player.Jump.performed += ctx => RefreshWebPageOrReloadScene();
    }

    void OnDisable()
    {
        gameController.Player.Jump.performed -= ctx => RefreshWebPageOrReloadScene();
    }
    
    void OnDestroy()
    {
        gameController.Player.Jump.performed -= ctx => RefreshWebPageOrReloadScene();
    }
}
