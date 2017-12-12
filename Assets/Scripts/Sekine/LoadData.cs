using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{

	void Start()
	{
		ReadPlayerPref.SetStringKey("1-1", "stage1");
	}
}