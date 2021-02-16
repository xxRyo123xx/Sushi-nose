using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToSushiGenerator : MonoBehaviour
{
    public GameObject eggObj;
    public GameObject tunaObj;
    public GameObject ebiObj;
    public GameObject sakanaObj;
    public GameObject anagoObj;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Util.isStart && Util.isReady && !Util.isEnd)
        {
            Util.isSucceed = false;
            Util.isReady = false;

            float netaNum = Random.Range(0, 5);
            GameObject selectNeta = null;
            switch (netaNum)
            {
                //
                case 0:
                    selectNeta = eggObj;
                    break;
                // 
                case 1:
                    selectNeta = tunaObj;
                    break;
                // 
                case 2:
                    selectNeta = ebiObj;
                    break;
                //
                case 3:
                    selectNeta = sakanaObj;
                    break;
                //
                case 4:
                    selectNeta = anagoObj;
                    break;
            }
            selectNeta.gameObject.tag = "Sushi";
            GameObject sushiObj = Instantiate(selectNeta);
            sushiObj.transform.parent = this.transform;
            float x = Random.Range(-4.0f, 4.1f);
            sushiObj.transform.localPosition = new Vector3(x, 0.0f, 0.0f);
        }
    }
}
