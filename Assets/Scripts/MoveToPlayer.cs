using System;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public GameObject player;
    public float offsetY = 2f;
    public float cameraZLayer = -10f;
    
    private void LateUpdate()
    {
        transform.position = new Vector3( player.transform.position.x, player.transform.position.y + offsetY, cameraZLayer);
    }
}
