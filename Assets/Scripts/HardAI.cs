using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAI : CarAI
{

	void Update ()
	{
		if (Vector3.Distance (this.transform.position, playerPrefab.transform.position) < detectPlayerDistance) {
			Vector3 delta = (playerPrefab.transform.position - transform.position).normalized;
			float moveSpeed = carSpeed * Time.deltaTime;
			transform.position = new Vector3 ((transform.position.x + (delta.x * moveSpeed)), transform.position.y);
		}
	}
}
