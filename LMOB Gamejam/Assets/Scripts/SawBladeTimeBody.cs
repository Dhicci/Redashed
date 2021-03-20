using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeTimeBody : MonoBehaviour
{

	public bool isRewinding = false;

	//public bool destroy_after = false;

	public float recordTime = 2f;

	public List<SawBladePointInTime> pointsInTime;

	Rigidbody2D rb;

	float rewind_time;
	float timer;
	bool still_rewinding = false;
	Vector3 still_position;

	// Use this for initialization
	void Start()
	{
		pointsInTime = new List<SawBladePointInTime>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (timer > -1)
		{
			timer += Time.deltaTime;
			if (timer >= rewind_time)
			{
				still_rewinding = false;
			}
		}
	}

	void FixedUpdate()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind()
	{
		if (pointsInTime.Count > 0)
		{
			SawBladePointInTime pointInTime = pointsInTime[0];
			transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			gameObject.GetComponent<SawbladeMove>().going = pointInTime.going;
			still_position = pointInTime.position;
			pointsInTime.RemoveAt(0);
		}
		else
		{
			transform.position = still_position;
			if (still_rewinding == false)
			{
				//pointsInTime.Clear();
				StopRewind();
			}

		}

	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new SawBladePointInTime(transform.position, transform.rotation, gameObject.GetComponent<SawbladeMove>().going));
	}

	public void StartRewind(float t)
	{
		still_rewinding = true;
		rewind_time = t;
		timer = 0;
		isRewinding = true;
		rb.isKinematic = true;
	}

	public void StopRewind()
	{
		isRewinding = false;
		rb.isKinematic = false;
	}
}
