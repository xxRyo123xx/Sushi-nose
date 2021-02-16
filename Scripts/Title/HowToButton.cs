using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToButton : MonoBehaviour
{
    public Button startButton;

    public void OnClick()
    {
        SceneManager.LoadScene("HowTo");
    }
}
