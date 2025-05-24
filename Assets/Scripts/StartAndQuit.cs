using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class StartAndQuit : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

   public void QuitGame()
    {
        Application.Quit();
    }

}
