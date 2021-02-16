using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmButton : MonoBehaviour
{
    public Sprite spOn;
    public Sprite spOff;
    private GameObject bgm;
    private Image img;

    private void Start()
    {
        bgm = GameObject.Find("Bgm");
        img = this.gameObject.GetComponent<Image>();
        if (Util.isBgmOn)
        {
            img.sprite = spOn;
        }
        else
        {
            img.sprite = spOff;
        }
    }

    public void OnClick()
    {
        //var img = this.gameObject.GetComponent<Image>();
        if (Util.isBgmOn)
        {
            img.sprite = spOff;
            bgm.gameObject.GetComponent<AudioSource>().Pause();
            Util.isBgmOn = false;
        }
        else
        {
            img.sprite = spOn;
            bgm.gameObject.GetComponent<AudioSource>().Play();
            Util.isBgmOn = true;
        }
    }
}
