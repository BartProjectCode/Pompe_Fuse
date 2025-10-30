using System;
using UnityEngine;

public class PumpToBoost : MonoBehaviour
{
    public Rigidbody2D rocketRb;
    private float force = 0.1f;
    private float maxVelocity = 15f;
    public bool canBoost;
    private float sensToBoost = 2f;
    public float sensToTorque = 0.1f;
    public GameObject smoke;
    public float offset = 1f;
    public float total;
    private float totalMax = 1f;
    private float timerBeforeVelocity = 3f;


    private bool canDivide;
    public float totalBoost;
    
    public LimitBounds limitBounds;
    public TimeToPump timeToPump;

    private void Start()
    {
        rocketRb = GetComponent<Rigidbody2D>();
        limitBounds = GetComponent<LimitBounds>();
        timeToPump = GetComponent<TimeToPump>();
    }

    private void Update()
    {
        
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        total += mouseY * Time.deltaTime;

        if (total <= 0)
        {
            total = 0;
        }
        else if (total >= totalMax)
        {
            total = totalMax;
        }

        if (total <= 0 && !canBoost)
        {
            canBoost = true;
        }


        //spawn point de la fumée lors du boost
        Vector2 smokeSpawnPoint = transform.position - transform.up;

        
        //Lorsqu'on pompe, la fusée est propulsée et fait spawn de la fumée
        if (mouseY >= sensToBoost && timeToPump.bPumpTime == false)
        {
            rocketRb.AddForce(transform.up * (mouseY * force), ForceMode2D.Impulse);
            Instantiate(smoke, smokeSpawnPoint, gameObject.transform.rotation);
            smoke.transform.position = new Vector3(smoke.transform.position.x, smoke.transform.position.y,
                smoke.transform.position.z + 0.4f);
            canBoost = false;
        }

        // if (mouseX >= sensToTorque)
        // {
        //     rocketRb.AddTorque(1f, ForceMode2D.Force);
        // }
        // else if (mouseX <= -sensToTorque)
        // {
        //     rocketRb.AddTorque(-1f, ForceMode2D.Force);
        // }
        
        if (mouseX >= sensToTorque && timeToPump.bPumpTime == false)
        {
            transform.Rotate(0, 0, -1);
        }
        else if (mouseX <= -sensToTorque && timeToPump.bPumpTime == false)
        {
            transform.Rotate(0, 0, 1);
        }

        
        //code relié au boost pendant le stop
        if (timeToPump.bPumpTime == true && mouseY >= sensToBoost)
        {
            totalBoost += mouseY;
        }
        
        if (timeToPump.activateBoost == true)
        {
            maxVelocity *= 3;
            rocketRb.AddForce(Vector3.up * (force * totalBoost), ForceMode2D.Impulse);
            totalBoost = 0;
            timeToPump.activateBoost = false;
            canDivide = true;
            timerBeforeVelocity = 3f;
        }

        if (timerBeforeVelocity > 0)
        {
            timerBeforeVelocity -= Time.deltaTime;
        }

        if (timerBeforeVelocity < 0 && canDivide)
        {
            canDivide = false;
            timerBeforeVelocity = 0;
            maxVelocity /= 3f;
        }
        
        
        
        //Set une velocity maximale
        if (rocketRb.linearVelocity.magnitude > maxVelocity)
        {
            rocketRb.linearVelocity = rocketRb.linearVelocity.normalized * maxVelocity;
        }
        
        SendWhenLimit();
        
    }

    private void SendWhenLimit()
    {
        if (limitBounds.sendLeft == true)
        {
            rocketRb.AddForce(Vector2.left * 4, ForceMode2D.Impulse);
            limitBounds.sendLeft = false;
        }
        else if (limitBounds.sendRight == true)
        {
            rocketRb.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
            limitBounds.sendRight = false;
        }
    }
    
}