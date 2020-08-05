using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding { get; private set; } = false;
    public float recordTime = 5f;

	private List<PointInTime> pointsInTime;
	private Rigidbody rb;
	private PlayerCollisions playerColl;


	// Use this for initialization
	void Start()
	{
		pointsInTime = new List<PointInTime>();
		//rb = GetComponent<Rigidbody>();
		playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisions>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && (playerColl.canUseButtons))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
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
			PointInTime pointInTime = pointsInTime[0];
			transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		}
		else
		{
			StopRewind();
		}
	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind()
	{
		isRewinding = true;
		//rb.isKinematic = true;
	}

	public void StopRewind()
	{
		isRewinding = false;
		//rb.isKinematic = false;
	}
}