using System;
using UnityEngine;
using TMPro;

public class OnCollisionEnterExplode : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI lost;    

    private void OnCollisionStay2D(Collision2D other)
    {
        lost.gameObject.SetActive(true);
        
        player.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        lost.gameObject.SetActive(true);
        
        player.SetActive(false);
    }
}
