using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    private bool up = true;
    void Update()
    {
        if (up)
        {
            transform.Translate(new Vector3(0f, 10f *Time.deltaTime, 0f));
        }
        else
        {
            transform.Translate(new Vector3(0f, -1f * Time.deltaTime, 0f));
        }
        if (transform.position[1] > 0)
        {
            up = false;
        }
        if (transform.position[1] < -4)
        {
            up = true;
        }

    }
}
