using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    private PlayerControllerInputAsset input;

    [SerializeField] Vector2 maxMovement;

    public InputAction playerMove { get; private set; }
    public InputAction playerFall { get; private set; }

    //movement
    private Vector2 movementVector;
    private float fallFloat;
    private Vector3 StartVelocity = Vector3.zero;
    private Rigidbody2D myRB;

    [SerializeField] private float movementSmoothing;

    [SerializeField] private float moveSpeed;

    Animator myAni;

    public float MovementSmoothing { get { return movementSmoothing; } set { movementSmoothing = value; } }

    private void Awake()
    {
        input = new PlayerControllerInputAsset();

        playerMove = input.Player.Move;
        playerFall = input.Player.space;

        myRB = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
    }

    private void Update()
    {
        movement();

        //Force Fix positions
        if (transform.position.y > maxMovement.y)
        {
            transform.position = new Vector3(transform.position.x, maxMovement.y, transform.position.z);
        }

        if (transform.position.y < -maxMovement.y)
        {
            transform.position = new Vector3(transform.position.x, -maxMovement.y, transform.position.z);
        }
    }

    private void movement()
    {
        movementVector = playerMove.ReadValue<Vector2>();
        fallFloat = playerFall.ReadValue<float>();

        float newYVelocity = myRB.velocity.y;


        // flipsprite
        if (movementVector.x != 0)
        {
            //transform.localScale = new Vector3(Mathf.Sign(movementVector.x), transform.localScale.y, transform.localScale.z);

        }
        //handle jump and fall
        if (fallFloat == 1 || movementVector.y<-0.5f)
        {
            myAni.SetBool("open", false);
            if (transform.position.y < -maxMovement.y)
            {
                //myRB.gravityScale = 0f;
                newYVelocity = 0f;
            }
            else
            {
                //myRB.gravityScale = 1f;
                newYVelocity = -5f;
            };
        }
        else
        {
            myAni.SetBool("open", true);
            if (transform.position.y > maxMovement.y)
            {
                //myRB.gravityScale = 0f;
                newYVelocity = 0f;
            }
            else
            {
                //myRB.gravityScale = -1f;
                newYVelocity = 5f;
            }
            
        }


        
        //Bind movement within box
        if ((movementVector.x<0 && transform.position.x < -maxMovement.x) || (movementVector.x > 0 && transform.position.x > maxMovement.x))
        {
            Vector3 VelocityChange = new Vector2(0, newYVelocity);
            VelocityChange = Vector3.SmoothDamp(myRB.velocity, VelocityChange, ref StartVelocity, movementSmoothing);
            myRB.velocity = new Vector3(VelocityChange.x, newYVelocity, VelocityChange.z);
        }
        else
        {
            Vector3 VelocityChange = new Vector2(Time.fixedDeltaTime * moveSpeed * 10 * movementVector.x, newYVelocity);
            VelocityChange = Vector3.SmoothDamp(myRB.velocity, VelocityChange, ref StartVelocity, movementSmoothing);
            myRB.velocity = new Vector3(VelocityChange.x, newYVelocity, VelocityChange.z);
        }

    }

    private void OnEnable()
    {
        playerMove.Enable();
        playerFall.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
        playerFall.Disable();
    }



}
