using System;
using UnityEngine;

public class LimitBounds : MonoBehaviour
{
    public float xLimit;

    private void Update()
    {
        if (transform.position.x >= xLimit)
        {
            transform.position = new Vector2(xLimit, transform.position.y);
        }
        else if (transform.position.x <= -xLimit)
        {
            transform.position = new Vector2(-xLimit, transform.position.y);
        }
    }
}
