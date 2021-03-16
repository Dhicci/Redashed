using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool time_out = false;

	// Update is called once per frame
	void Update()
	{
		if (time_out == false)
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
			}

			if (Input.GetButtonDown("Crouch"))
			{
				crouch = true;
			}
			else if (Input.GetButtonUp("Crouch"))
			{
				crouch = false;
			}
		}
		else
        {
			horizontalMove = 0;
			jump = false;
			crouch = false;
        }
	}

	void FixedUpdate()
	{
			// Move character
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			jump = false;
		
	}
}