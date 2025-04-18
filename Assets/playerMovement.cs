using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float movementX; 
    private float movementY;
    private float movementZ;
    Vector3 currentMovement;
    [SerializeField] int trick = 3;


    Rigidbody rb => GetComponent<Rigidbody>();
    [SerializeField] private float speed = 11.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void FixedUpdate() //runs every frame
    {   
        Vector3 movement = new(movementX, movementY, movementZ);
        rb.AddForce(movement * speed);
        currentMovement = movement;
    }

    void OnMovement(InputValue value) { //named after the specific input
        Vector3 v = value.Get<Vector3>();
        Debug.Log("Move Function Called");
        Debug.Log(v);
        movementX = v.x;
        movementZ = v.y; //up
        movementY = v.z * 5;

    }
    
    void OnDirectionalTrick(InputValue value) {
        if (currentMovement == Vector3.zero) {
            rb.position = new Vector3(rb.position.x, rb.position.y + trick, rb.position.z);
        } else {
             rb.position = new Vector3(rb.position.x + (movementX * trick), rb.position.y +
             (movementY * trick), rb.position.z + (movementZ * trick));
        }
    }

    void OnFire(InputValue value) {
        
    }

    //whenever the game engine detects input, it'll call the OnMove function
    //because the behavior of the input is that it Sends Messages, calling this function
    //we then use this function to update global variables. which we can call in the Update function
}
