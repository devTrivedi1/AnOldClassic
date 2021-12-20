using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private float horizontalInput;
	private float verticalInput;
	public float speed = 10f;

	private bool isJumping;

	private Rigidbody playerRB;
	void Start()
	{
		playerRB = GetComponent<Rigidbody>();
	}
	void Update()
	{
		ReadInputs();
	}
	void FixedUpdate()
	{
		Move();
	}

	void ReadInputs()
	{
		if (Input.GetButtonDown("Jump"))
		{
			isJumping = true;
		}

		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
	}

	void Move()
	{
		float y = playerRB.velocity.y;
		playerRB.velocity = new Vector2(horizontalInput * speed, y);

	}
}
