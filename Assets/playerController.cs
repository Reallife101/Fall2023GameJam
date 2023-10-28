using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    private PlayerControllerInputAsset input;

    public InputAction playerMove { get; private set; }
    public InputAction playerFall { get; private set; }

    //movement
    private Vector2 movementVector;
    private Vector3 StartVelocity = Vector3.zero;
    private Rigidbody2D myRB;

    [SerializeField] private float movementSmoothing;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float ascendSpeed;

    public float MovementSmoothing { get { return movementSmoothing; } set { movementSmoothing = value; } }

    private void Awake()
    {
        input = new PlayerControllerInputAsset();

        playerMove = input.Player.Move;

        myRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement();
    }

    private void movement()
    {
        movementVector = playerMove.ReadValue<Vector2>();

        // flipsprite
        if (movementVector.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movementVector.x), transform.localScale.y, transform.localScale.z);
        }

        Vector3 VelocityChange = new Vector2(Time.fixedDeltaTime * moveSpeed * 10 * movementVector.x, myRB.velocity.y);
        myRB.velocity = Vector3.SmoothDamp(myRB.velocity, VelocityChange, ref StartVelocity, movementSmoothing);

    }

    private void OnEnable()
    {
        playerMove.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
    }



}
