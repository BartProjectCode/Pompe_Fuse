using System;
using UnityEngine;

public class TimeToPump : MonoBehaviour
{
    public bool bPumpTime;
    public Vector3 positionToStop;
    public float maxCountDown;
    public float countDown = 3f;
    public PumpToBoost pumpToBoost;
    public bool activateBoost;

    public GameObject timeStopScreen;
    

    private void Start()
    {
        pumpToBoost = GetComponent<PumpToBoost>();
        
        maxCountDown = countDown;
    }

    private void Update()
    {
        PumpTime();
    }

    private void PumpTime()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            positionToStop = transform.position;
            bPumpTime = true;
        }

        if (bPumpTime)
        {
            timeStopScreen.SetActive(true);
            countDown -= Time.deltaTime;
            transform.position = positionToStop;
        }

        if (countDown <= 0)
        {
            timeStopScreen.SetActive(false);
            bPumpTime = false;
            countDown = 3f;
            activateBoost = true;
        }
    }
    
    
}
