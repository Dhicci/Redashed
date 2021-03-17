using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeBody : MonoBehaviour
{

	public bool isRewinding = false;

	public bool destroy_after = false;

	public float recordTime = 2f;

	public List<PointInTime> pointsInTime;

	Rigidbody2D rb;

	Vector3 start_pos, drift_pos;

	private float timer = 0;

	private bool is_drifting = false;

	float drift_time = 0;

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

	public void TakePosition(float time_left)
    {
		drift_time = time_left;
		start_pos = pointsInTime[pointsInTime.Count - 1].position;
		drift_pos = transform.position;
		is_drifting = true;
		rb.isKinematic = true;
	}

	private void StopDrift()
    {
		rb.velocity = new Vector3(0, 0, 0);
		rb.isKinematic = false;
		is_drifting = false;
		transform.position = start_pos;
		pointsInTime.Clear();
		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

    private void Update()
    {
        if (is_drifting)
        {
			timer += Time.deltaTime;
			if (timer > drift_time)
            {
				timer = 0;
				StopDrift();
            }
			else
            {
				float ratio = timer / drift_time;
				transform.position = Vector3.Lerp(drift_pos, start_pos, ratio);
            }
        }
    }
}
