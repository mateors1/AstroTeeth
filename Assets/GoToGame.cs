using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            // WebGL: Close the tab (Note: This may not work in all browsers due to security restrictions)
            Application.OpenURL("about:blank");
#else
        // Standalone or Editor: Quit the application
        Application.Quit();
#endif
    }
}

