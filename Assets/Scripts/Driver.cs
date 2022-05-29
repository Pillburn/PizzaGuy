using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float steeringSpeed = 0.12f;
    public float speed = 20.0f;

    public float boostSpeed = 40.0f;

    public float slowSpeed = 15.0f;

    public bool slowActive;
    public bool boostActive;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steeringSpeed * Time.deltaTime;
        float accelerationAmt = Input.GetAxis("Vertical")*speed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,accelerationAmt,0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        speed = slowSpeed;
        slowActive = true;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost" && boostActive == false) 
                {
                    Debug.Log("SPEEEEEEEED BOOST!!");
                    speed = boostSpeed; 
                }

                if(other.tag == "Slow" && slowActive == false)
                {
                    Debug.Log("SLOOOOOOOW DOOOOOOOWN!!");
                    speed = slowSpeed;
                    slowActive = true;
                }
            }
    }
