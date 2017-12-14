using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

	private Vector3 cameraPosition;
	private float moveSpeed = 0.02f;

	private bool start = false;

	[SerializeField]
	private BackGroundMove backGround;

	// Use this for initialization
	void Start()
	{
		cameraPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (start)
		{
			cameraPosition.x += moveSpeed;
			transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z);

			backGround.BackMove();
		}
	}

	public void CameraMoveStart()
	{
		start = true;
	}

	public bool IsStart()
	{
		return start;
	}
}