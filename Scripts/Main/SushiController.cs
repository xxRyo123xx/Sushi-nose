using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SushiController : MonoBehaviour
{
    private Rigidbody rb;
    private SoundController sound;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject child = this.transform.Find("Cube").gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, -Util.currentSpeed, 0.0f);
        //rb.AddForce(0.0f, -Util.currentSpeed, 0.0f, ForceMode.Impulse);
        sound = new SoundController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject parent = this.transform.parent.gameObject;
        if (collision.gameObject.tag == "Rice" && !Util.isEnd)
        {
            Util.isSucceed = true;
            Util.targetX = parent.transform.localPosition.x;
            //rb.velocity = Vector3.zero;
            //rb.useGravity = true;
            if (Util.isBgmOn)
            {
                sound.Sound(1);
            }
        }
        else
        {
            Util.isSucceed = false;
            Util.isEnd = true;

            GameObject masterObj = GameObject.Find("Master");
            Master master = masterObj.GetComponent<Master>();
            master.EndProcess(this.gameObject, parent);
            if (Util.isBgmOn)
            {
                sound.Sound(2);
            }
        }
    }
}
