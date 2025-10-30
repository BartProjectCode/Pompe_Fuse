using UnityEngine;
using TMPro;

public class TrackUpdateHeight : MonoBehaviour
{
    public TextMeshProUGUI heightText;
    public float height;
    
    

    // Update is called once per frame
    void Update()
    {
        height = transform.position.y;
        
        heightText.text = "Hauteur : " + Mathf.RoundToInt(height) + " m";

    }
}
