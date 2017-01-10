using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDeactivation : MonoBehaviour
{
	void Update ()
	{
		RaycastHit2D hitInfo = GetComponent<DrawLine> ().hitInfo;
		if (hitInfo.collider != null)
			this.gameObject.SetActive (false);
	}
}