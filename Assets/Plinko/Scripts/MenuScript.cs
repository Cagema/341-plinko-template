using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ClickPlayButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
