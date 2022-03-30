using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//DELETE

public class Floating : MonoBehaviour
{
    public float speed = 1;
    public float amplitude = 1; //values seems to give the right harmony to the floating to the character. 
    public Vector3 equilibriumPoint;
    public Vector3 Velocity;

    void Start()
    {
        equilibriumPoint.y = this.transform.position.y;
    }

    void Update()
    {
        HarmonicMovement();
    }

    void HarmonicMovement()
    {

        //simplify this code maybe? 


        //circular
        //Velocity.x = (Mathf.Sin(Time.time * speed) * amplitude) + equilibriumPoint.x;
        //Velocity.y = (Mathf.Cos(Time.time * speed) * amplitude) + equilibriumPoint.y;
        //2. Vertical
        transform.position = new Vector3(transform.position.x, equilibriumPoint.y + (Mathf.Sin(Time.time) * speed), transform.position.z);
        //Velocity.y = (Mathf.Sin(Time.time * speed) * amplitude) + equilibriumPoint.y;
    }


}
