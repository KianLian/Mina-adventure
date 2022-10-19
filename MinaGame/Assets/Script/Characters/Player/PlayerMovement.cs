using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]
   private float _speed = 0;
    [SerializeField]
    private float jumpForce;

     private float horizontalMovement;

    [SerializeField]
    private float _fallGravityMulitplier;
    [SerializeField]
    private float _lowJumpMultiplier;
    [SerializeField]
    private bool jump;

    private Rigidbody2D myRigidbody = null;
    private Collider2D myCapsuleCollider = null;
    private PlayerInputAction myPlayerInputAction = null;
  
    [SerializeField]
    private Transform[] _feetTransforms = new Transform[2];
    [SerializeField]
    private LayerMask groundLayerMask = 0;
    private Collider2D[] groundDetectionColliders = new Collider2D[1];


    [SerializeField]
    private bool pressedJump = false;
    [SerializeField]
    private bool isGrounded = true;

    private void Awake()
    {
        myPlayerInputAction = new PlayerInputAction();
        myPlayerInputAction.Enable();

        myRigidbody  = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    void Start()
    { 
        bool a = GameManager.AddPlayer(this.gameObject);
        if(a)
            Debug.LogWarning("hehehe");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = myPlayerInputAction.Player.Movement.ReadValue<float>();

        isGrounded = CheckGround();

        pressedJump = myPlayerInputAction.Player.Jump.IsPressed();

        if (pressedJump && isGrounded && !jump)
            jump = true;


    }

    void FixedUpdate()
    {
        if (horizontalMovement != 0)
            myRigidbody.velocity = new Vector2(horizontalMovement * _speed, myRigidbody.velocity.y);

        if (jump)
        {
            myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
        if (myRigidbody.velocity.y < 0)
            myRigidbody.gravityScale = _fallGravityMulitplier;
        else
            myRigidbody.gravityScale = myRigidbody.velocity.y switch
            {
                > 0 when !pressedJump => _lowJumpMultiplier,
                _ => 1f
            };


    }


    bool CheckGround()
    {
        return Physics2D.OverlapPointNonAlloc(_feetTransforms[0].position, groundDetectionColliders, groundLayerMask) > 0 ||
               Physics2D.OverlapPointNonAlloc(_feetTransforms[1].position, groundDetectionColliders, groundLayerMask) > 0;
    }

}
