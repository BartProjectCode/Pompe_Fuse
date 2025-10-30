using System;
using UnityEngine;

public class LimitBounds : MonoBehaviour
{
    public float xLimit;
    public bool sendLeft;
    public bool sendRight;

    private void Update()
    {
        if (transform.position.x > xLimit + 1)
        {
            // transform.position = new Vector2(xLimit, transform.position.y);
            transform.position = new Vector2(-xLimit - 0.9f, transform.position.y);
            // sendLeft = true;

        }
        else if (transform.position.x < -xLimit - 1)
        {
            // transform.position = new Vector2(-xLimit, transform.position.y);
            transform.position = new Vector2(xLimit + 0.9f, transform.position.y);
            // sendRight = true;
        }
    }
}
