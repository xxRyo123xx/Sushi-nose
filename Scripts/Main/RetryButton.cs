using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnClick()
    {
        Util.retryCount++;
        if (Util.retryCount % 3 == 0)
        {

        }

        Util.isStart = false;
        Util.isSucceed = false;
        Util.isReady = false;
        Util.isEnd = false;
        Util.currentSpeed = 0.0f;
        Util.targetX = 0.0f;
        SceneManager.LoadScene("Main");
    }
}
