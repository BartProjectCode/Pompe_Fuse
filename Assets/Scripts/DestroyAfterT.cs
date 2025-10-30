using System;
using UnityEngine;

public class DestroyAfterT : MonoBehaviour
{
    public float t = 1f;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.4f);
    }

    void Update()
    {
        t -= Time.deltaTime;

        if (t <= 0)
        {
            Destroy(gameObject);
        }

        
    }
}
