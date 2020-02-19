using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (SceneManager.GetSceneByName("UIContainer").isLoaded == false)
            {
                SceneManager.LoadScene("UIContainer", LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.UnloadSceneAsync("UIContainer");
            }
        }
    }
}
