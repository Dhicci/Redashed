using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController controller;
	public Animator anim;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool time_out = false;
	bool ground_true = false;
	bool dash = false;

	// Update is called once per frame
	void Update()
	{
		if (Time.timeScale == 0)
        {
			if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetButtonDown("Crouch") || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("Dash"))
            {
				Time.timeScale = 1;
            }
			else if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
            {
				Time.timeScale = 1;
				jump = true;
				ground_true = true;
			}
			
        }
		if (time_out == false)
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


			if (Input.GetButtonDown("Dash"))
			{
				dash = true;
			}
			if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
			{
				jump = true;
			}

			if (Input.GetButtonDown("Crouch") || Input.GetKeyDown(KeyCode.DownArrow))
			{
				crouch = true;
			}
			else if (Input.GetButtonUp("Crouch") || Input.GetKeyUp(KeyCode.DownArrow))
			{
				crouch = false;
			}
		}
		else
        {
			dash = false;
			horizontalMove = 0;
			jump = false;
			crouch = false;
			ground_true = false;
        }
	}

	void FixedUpdate()
	{
		// Move character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ground_true, dash);
		ground_true = false;
		jump = false;
		dash = false;
	}
}