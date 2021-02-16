using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMaster : MonoBehaviour
{
    public Text Title;
    public Text startText;
    public Text howToText;

    private void Awake()
    {
        SystemLanguage sl = Application.systemLanguage;
        switch (sl)
        {
            case SystemLanguage.Japanese:
                Title.text = "すしのせ";
                Title.fontSize = 200;
                startText.text = "スタート";
                howToText.text = "遊び方";
                break;
            case SystemLanguage.English:
            default:
                Title.text = "Sushi-nose";
                Title.fontSize = 175;
                startText.text = "Start";
                howToText.text = "How to play";
                break;
        }
    }
}
