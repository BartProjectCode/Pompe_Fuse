using System;
using UnityEngine;
using TMPro;

public class WinOnLanding : MonoBehaviour
{
    public bool isWinGrounded;
    public float angleToLand;
    public TextMeshProUGUI youWin;

    private void Update()
    {
        if (isWinGrounded)
        {
            youWin.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WinGround") && transform.rotation.z >= -angleToLand && transform.rotation.z <= angleToLand)
        {
            isWinGrounded = true;
            Debug.Log("WIN!!!!");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WinGround"))
        {
            isWinGrounded = false;
        }
    }
}
