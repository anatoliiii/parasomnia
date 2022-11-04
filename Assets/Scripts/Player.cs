using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// Constant
	const float jumpCheckPreventionTime = 0.5f;

	// Callback
	public delegate void CollectCoinCallback();
	public CollectCoinCallback onCollectCoin;

	// Public
	[Header("Physic Setting")]
	public LayerMask groundLayerMask;

	[Header("Move & Jump Setting")]
	public float moveSpeed = 10;
	public float fallWeight = 5.0f;
	public float jumpWeight = 0.5f;
	public float jumpVelocity = 100.0f;

	// Internal Data

	// State of the player (jumping or not)
	protected bool jumping = false;			// state of player (jumping or not )

	//
	protected Vector3 moveVec = Vector3.zero; // movement speed of player
	protected float jumpTimestamp;			// start jump timestamp

	protected Animator animator;				// reference to the animator
	protected new Rigidbody2D rigidbody;			// reference to the rigidbody



	// Start is called before the first frame update
	private void Awake()
	{
		animator = GetComponentInChildren<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void UpdateWhenJumping()
	{
		bool isFalling = rigidbody.velocity.y <= 0;

		float weight = isFalling ? fallWeight : jumpWeight;

		// Assign new velocity
		rigidbody.velocity = new Vector2(moveVec.x * moveSpeed, rigidbody.velocity.y);
		rigidbody.velocity += Vector2.up * Physics.gravity.y * weight * Time.deltaTime;

		GroundCheck();
	}

	void UpdateWhenGrounded()
	{
		// 1 
		rigidbody.velocity = moveVec * moveSpeed;

		// 2
		

		// 3
		CheckShouldFall();
	}

	private void FixedUpdate()
	{
		if (jumping == false)
		{
			// 2
			UpdateWhenGrounded();
		}
		else
		{
			// 3
			UpdateWhenJumping();
		}
	}

	// Update is called once per frame
	void Update()
	{
		UpdateAnimation();
	}

	public void OnJump()
    {
		HandleJump();
		Debug.Log("d");
    }

	public void OnMove(InputValue input)
    {
		Vector2 inputVec = input.Get<Vector2>();

		moveVec = new Vector2(inputVec.x, 0);
    }

	#region Jump & Fall & Ground Logic

	protected bool HandleJump()
	{
		if (jumping)
		{
			return false;
		}

		jumping = true;
		jumpTimestamp = Time.time;
		rigidbody.velocity = new Vector3(0, jumpVelocity, 0); // Set initial jump velocity

		return true;
	}

	void CheckShouldFall()
	{
		if(jumping)
		{
			return;	// No need to check if in the air
		}

		bool hasHit = Physics.CheckSphere(transform.position, 0.1f, groundLayerMask);

		if (hasHit == false)
		{
			jumping = true;
		}
	}

	void GroundCheck()
	{
		if(jumping == false)
		{
			return;	// No need to check
		}

		if (Time.time < jumpTimestamp + jumpCheckPreventionTime)
		{
			return;
		}

		bool hasHit = Physics.CheckSphere(transform.position, 0.1f, groundLayerMask);
		
		if(hasHit)
		{
			jumping = false;
		}
	}

	#endregion

	void UpdateAnimation()
	{
		if (animator == null)
		{
			return;
		}

		animator.SetBool("jumping", jumping);
		animator.SetFloat("moveSpeed", moveVec.magnitude);
	}

}
