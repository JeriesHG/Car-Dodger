using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{

	public float detectPlayerDistance = 2f;
	public float carSpeed = 0.5f;
	public GameObject playerPrefab;

	// Use this for initialization
	void Start ()
	{
		playerPrefab = GameObject.FindGameObjectWithTag ("Player");
	}


	void Update ()
	{

	}
}
