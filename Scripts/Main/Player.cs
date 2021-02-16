using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Util.isEnd)
        {
            TouchInfo info = TouchUtil.GetTouch();
            if (info == TouchInfo.Moved)
            {
                Vector3 swipePos = TouchUtil.GetTouchPosition();
                swipePos.z = 20.0f;

                Vector3 swipeWorldPos = Camera.main.ScreenToWorldPoint(swipePos);
                this.transform.position = new Vector3(swipeWorldPos.x, 0.0f, 0.0f);
            }
        }
    }
}
