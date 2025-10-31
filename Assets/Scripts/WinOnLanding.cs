using System;
using UnityEngine;
using TMPro;

public class WinOnLanding : MonoBehaviour
{
    public bool isWinGrounded;
    public bool isGrounded;
    public float angleToLand;
    public TextMeshProUGUI youWin;
    public Rigidbody2D rocketRb;

    private void Start()
    {
        rocketRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isWinGrounded)
        {
            youWin.gameObject.SetActive(true);
        }

        if (isGrounded)
        {
            rocketRb.freezeRotation = false;
        }
        else
        {
            rocketRb.freezeRotation = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WinGround") && transform.rotation.z >= -angleToLand && transform.rotation.z <= angleToLand)
        {
            isWinGrounded = true;
        }
        
        if (other.gameObject.CompareTag("Comet") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("WinGround"))
        {
            isGrounded = true;
            rocketRb.freezeRotation = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WinGround"))
        {
            isWinGrounded = false;
        }
        
        if (other.gameObject.CompareTag("Comet") || other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
