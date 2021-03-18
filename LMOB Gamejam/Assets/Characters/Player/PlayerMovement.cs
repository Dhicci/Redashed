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
	bool ground_true = false;

	// Update is called once per frame
	void Update()
	{
		if (Time.timeScale == 0)
        {
			if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetButtonDown("Crouch"))
            {
				Time.timeScale = 1;
            }
			else if(Input.GetButtonDown("Jump"))
            {
				Time.timeScale = 1;
				jump = true;
				ground_true = true;
			}
        }
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
			ground_true = false;
        }
	}

	void FixedUpdate()
	{
		// Move character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ground_true);
		ground_true = false;
		jump = false;
		
	}
}