using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToMaster : MonoBehaviour
{
    public Text discriptText;
    SystemLanguage sl;
    private float time = 0.0f;
    private bool isTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        Util.isStart = true;
        Util.isReady = true;
        sl = Application.systemLanguage;
        switch (sl)
        {

            case SystemLanguage.Japanese:
                discriptText.text = "スワイプで皿を動かし\n落ちてくる寿司ネタを\nシャリの上にのせましょう\nめざせハイスコア!";
                break;
            case SystemLanguage.English:
            default:
                discriptText.text = "Swipe to move the plate.\nFalling sushi material,\nput it on the rice.\nLet’s aim for a high score!";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Util.isSucceed)
        {
            time += Time.deltaTime;
            if (time > 0.3f)
            {
                GameObject neta = GameObject.FindGameObjectWithTag("Sushi");
                Destroy(neta);
                Util.isReady = true;
                time = 0.0f;
            }
        }
        TouchInfo info = TouchUtil.GetTouch();
        if (info == TouchInfo.Ended)
        {
            Util.isStart = false;
            Util.isSucceed = false;
            Util.isReady = false;
            Util.isEnd = false;
            Util.currentSpeed = 0.0f;
            Util.targetX = 0.0f;
            SceneManager.LoadScene("Title");
        }
    }
}
