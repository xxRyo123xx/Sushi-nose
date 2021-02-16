using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayer : MonoBehaviour
{
    private float preTargetX;
    private float distanceX;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        preTargetX = 0.0f;
        distanceX = 0.0f;
        direction = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float floorTargetX = Util.targetX * 10;
        floorTargetX = Mathf.Floor(floorTargetX) / 10;
        float abs = Mathf.Abs(floorTargetX - preTargetX);
        if (abs > 0.0f)
        {
            distanceX = floorTargetX - preTargetX;
            if (distanceX > 0.0f)
            {
                direction = 0.15f;
            }
            else
            {
                direction = -0.15f;
            }
        }
        else
        {
            float currentDistance = Mathf.Abs(floorTargetX - this.transform.position.x);
            if (currentDistance > 0.1f)
            {
                this.transform.position += new Vector3(direction, 0.0f, 0.0f);
            }
        }
        preTargetX = floorTargetX;
    }
}
