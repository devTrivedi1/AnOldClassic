using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	Rigidbody playerRB;
	private bool isJumping;
	private float jumpHeight = 5;

	[SerializeField] Vector3 gravity;
	[SerializeField] Vector3 gravityFall;
	[SerializeField] Vector3 jumpForce;
	public bool isGrounded;

	void Start()
	{
		isGrounded = GameObject.FindGameObjectWithTag("Ground");
		playerRB = GetComponent<Rigidbody>();
	}
	void Update()
	{
		ReadInputs();
	}
	void FixedUpdate()
	{
		if (isJumping)
		{
			Jumping();
			isJumping = false;
            isGrounded = false;
		}
	}

	void ReadInputs()
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			isJumping = true;
		}
	}
	void Jumping()
	{
		Physics.gravity = gravity;

		float x = playerRB.velocity.x;
		float z = playerRB.velocity.z;

		playerRB.velocity = jumpForce;

		if (playerRB.velocity.y < 0)
		{
			Physics.gravity = gravityFall;
		}
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
