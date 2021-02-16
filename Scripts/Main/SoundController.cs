using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void Sound(int num)
    {
        GameObject tmpObj = GameObject.Find("SoundEffect");
        switch (num)
        {
            case 0:
                var update = tmpObj.gameObject.transform.Find("UpdateScore");
                update.gameObject.GetComponent<AudioSource>().Play();
                break;
            case 1:
                var succeed = tmpObj.gameObject.transform.Find("Succeed");
                succeed.gameObject.GetComponent<AudioSource>().Play();
                break;
            case 2:
                var failed = tmpObj.gameObject.transform.Find("Failed");
                failed.gameObject.GetComponent<AudioSource>().Play();
                break;
        }
    }
}
