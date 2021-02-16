using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToSushiController : MonoBehaviour
{
    private SoundController sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = new SoundController();
        GameObject parent = this.transform.parent.gameObject;
        Util.targetX = parent.transform.localPosition.x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rice" && !Util.isEnd)
        {
            Util.isSucceed = true;
            if (Util.isBgmOn)
            {
                sound.Sound(1);
            }
        }
    }
}
