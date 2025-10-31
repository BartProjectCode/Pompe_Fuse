using System;
using UnityEngine;

public class OnCollisionBoom : MonoBehaviour
{
    public WinOnLanding winOnLanding;
    public bool lost;

    private void Start()
    {
        winOnLanding = GetComponent<WinOnLanding>();
    }

    private void Update()
    {
        if (lost && !winOnLanding.isWinGrounded)
        {
            Destroy(gameObject);
        }

        Debug.Log(winOnLanding.angleToLand);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Comet") && transform.rotation.z < -winOnLanding.angleToLand || transform.rotation.z > winOnLanding.angleToLand || transform.position.y < other.gameObject.transform.position.y)
        {
            lost = true;
        }
        else if (other.gameObject.CompareTag("WinGround") && transform.rotation.z < -winOnLanding.angleToLand || transform.rotation.z > winOnLanding.angleToLand || transform.position.y < other.gameObject.transform.position.y)
        {
            lost = true;
        }
    }
}
