﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadActivation : MonoBehaviour
{

	public LayerMask roadLayer;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == Mathf.Log (roadLayer.value, 2f)) {
			other.transform.GetChild (0).gameObject.SetActive (true);
		}
	} 
}
