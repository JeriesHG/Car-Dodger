﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDeactivation : MonoBehaviour
{
	public LayerMask roadLayer;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == Mathf.Log (roadLayer.value, 2f)) {
			other.gameObject.SetActive (false);
		}
	} 
}