using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
	[SerializeField]
	GameObject mainCamera;

	[SerializeField]
	List<GameObject> startPoint;

	[SerializeField]
	List<GameObject> endPoint;

	void Start()
	{
		
	}

	void Update()
	{
		for (int i = 0; i < endPoint.Count; i++)
		{
			if (mainCamera.transform.position.x - endPoint[i].transform.position.x > 9)
			{
				int newLeft = i - 1;

				if (newLeft < 0)
					newLeft = 2;

				startPoint[i].transform.position = endPoint[newLeft].transform.position;
			}
		}
	}
}