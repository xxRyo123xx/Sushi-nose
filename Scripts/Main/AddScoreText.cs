using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreText : MonoBehaviour
{
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            time += Time.deltaTime;
            if (time > 0.4f)
            {
                this.gameObject.SetActive(false);
                time = 0.0f;
            }
        }
    }
}
