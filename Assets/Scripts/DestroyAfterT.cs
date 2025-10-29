using UnityEngine;

public class DestroyAfterT : MonoBehaviour
{
    public float t = 1f;

    void Update()
    {
        t -= Time.deltaTime;

        if (t <= 0)
        {
            Destroy(gameObject);
        }
    }
}
