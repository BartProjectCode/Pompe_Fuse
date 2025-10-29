using System;
using UnityEngine;

public class PumpToBoost : MonoBehaviour
{
    public Rigidbody2D rocketRb;
    public float force;
    public float maxVelocity = 10f;
    public bool canBoost;
    public float sensToBoost = 6f;
    public float sensToTorque = 2f;
    public GameObject smoke;
    public float offset = 1f;
    public float total;
    private float totalMax = 1f;


    private void Start()
    {
        rocketRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     rocketRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        // }

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

        // if (total <= 0.3f)
        // {
        //     total = 0;
        // }

        if (total <= 0 && !canBoost)
        {
            canBoost = true;
        }

        // Debug.Log(total);


        Vector2 smokeSpawnPoint = new Vector2(transform.position.x, transform.position.y - offset);

        if (mouseY >= sensToBoost)
        {
            // maxVelocity = 10f;
            rocketRb.AddForce(transform.up * force, ForceMode2D.Impulse);
            Instantiate(smoke, smokeSpawnPoint, gameObject.transform.rotation);
            canBoost = false;
        }

        if (mouseX >= sensToTorque)
        {
            rocketRb.AddTorque(1f, ForceMode2D.Force);
        }
        else if (mouseX <= -sensToTorque)
        {
            rocketRb.AddTorque(-1f, ForceMode2D.Force);
        }
        // else
        // {
        //     rocketRb.totalTorque = 0;
        // }


        //Set une velocity maximale
        if (rocketRb.linearVelocity.magnitude > maxVelocity)
        {
            rocketRb.linearVelocity = rocketRb.linearVelocity.normalized * maxVelocity;
        }

        Debug.Log(mouseY);
    }
}