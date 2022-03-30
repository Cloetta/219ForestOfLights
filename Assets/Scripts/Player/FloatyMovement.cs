using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO CLEAN - All bugs solved for now.

[RequireComponent(typeof(CharacterController))]
public class FloatyMovement: MonoBehaviour
{

    //NOTES: character controller in this case sounds like the best option in combo with the floating script and the mouse controller script for the camera.


    CharacterController charContoller;
    public float moveSpeed = 5f;
    public float rotationSpeed = 0.1f;
    public float floatingSpeed = 1;
    //public float amplitude = 1; //values seems to give the right harmony to the floating to the character. 
    public Vector3 equilibriumPoint;
    public Vector3 Velocity;
    public bool isMoving;
    //jump?
    //public float jumpSpeed = 8f;

    public Terrain ground;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        charContoller = GetComponent<CharacterController>();
        equilibriumPoint.y = this.transform.position.y;
        isMoving = false;
    }

    void Update()
    {
        // ---------- BUUUUUG ----------------- 
        //Ci deve stare un punto di reset del punto armonico, perchè aumenta e conseguentemente pare che il pg va sempre più in alto nel tempo
       

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //modificare per un movimento leggermente più fluido
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        charContoller.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        HarmonicMovement();

        //if (moveDirection == Vector3.zero)
        //{
        //    isMoving = false;
        //}
        //else
        //{
        //    isMoving = true;
        //}


        //if (isMoving == false)
        //{

        //    //character floats
        //}
        //else
        //{
        //    //do nothing
        //}


    }

    void HarmonicMovement()
    {

        //simplify this code maybe? 


        //circular
        //Velocity.x = (Mathf.Sin(Time.time * speed) * amplitude) + equilibriumPoint.x;
        //Velocity.y = (Mathf.Cos(Time.time * speed) * amplitude) + equilibriumPoint.y;
        //2. Vertical
        
        transform.position = new Vector3(transform.position.x, equilibriumPoint.y + (Mathf.Sin(Time.time) * floatingSpeed), transform.position.z);

        equilibriumPoint.y = ground.SampleHeight(transform.position) + 0.5f;

        //Debug.Log("this is equilibrium : " + equilibriumPoint.y);
        //Velocity.y = (Mathf.Sin(Time.time * speed) * amplitude) + equilibriumPoint.y;
    }

}




