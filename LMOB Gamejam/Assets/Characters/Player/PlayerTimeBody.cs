using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeBody : MonoBehaviour
{

	public bool isRewinding = false;

	public bool destroy_after = false;

	public float recordTime = 7f;

	public List<PointInTime> pointsInTime;

	Rigidbody2D rb;

	Vector3 start_pos, drift_pos;

	private float timer;

	// Use this for initialization
	void Start()
	{
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (isRewinding)
        {

        }
		else
			Record();
	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	/*public void StartRewind()
	{
		rb.velocity = new Vector3(0, 0, 0);
		rb.isKinematic = true;
		PointInTime pointInTime = pointsInTime[pointsInTime.Count - 1];
		transform.position = pointInTime.position;
		transform.rotation = pointInTime.rotation;
		pointsInTime.Clear();
	}

	public void StopRewind()
	{
		isRewinding = false;
		rb.isKinematic = false;
	}*/

	public void TakePosition(float time_left)
    {
		start_pos = pointsInTime[pointsInTime.Count - 1].position;
	}
}
