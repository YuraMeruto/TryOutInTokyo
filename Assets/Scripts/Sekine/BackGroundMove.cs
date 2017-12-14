using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
	[SerializeField]
	GameObject mainCamera;

	[SerializeField]
	GameObject[] startPoint = new GameObject[3];

	[SerializeField]
	GameObject[] endPointStone = new GameObject[3];

	[SerializeField]
	GameObject BackGround;

	[SerializeField]
	GameObject[] Images = new GameObject[3];

	[SerializeField]
	GameObject[] endPointBack = new GameObject[3];

	void Start()
	{
		
	}

	public void BackMove()
	{
		BackGround.transform.position += new Vector3(0.01f, 0.0f, 0.0f);

		for (int i = 0; i < 3; i++)
		{
			if (mainCamera.transform.position.x - endPointStone[i].transform.position.x > 9)
			{
				int newLeft = i - 1;

				if (newLeft < 0)
					newLeft = 2;

				startPoint[i].transform.position = endPointStone[newLeft].transform.position;
			}

			if (mainCamera.transform.position.x - endPointBack[i].transform.position.x > 9)
			{
				int newLeft = i - 1;

				if (newLeft < 0)
					newLeft = 2;

				Images[i].transform.position = endPointBack[newLeft].transform.position;
			}
		}
	}
}