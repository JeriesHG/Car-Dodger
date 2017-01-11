using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{

	public float spawnChance = 0.2f;
	public GameObject test;

	private Tile2D.TileLayer2D roadLayer;

	// Use this for initialization
	void Start ()
	{
		//grabs first layer, it should be the room layer
		roadLayer = GetComponent<Tile2D.TileRoom2D> ().roomLayers [0];
		Transform selectedTile = retrieveRandomPosition ();
		Instantiate (test, new Vector3 (selectedTile.position.x, selectedTile.position.y), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private Transform retrieveRandomPosition ()
	{
		
		int randomPosition = Random.Range (0, roadLayer.transform.childCount);

		return roadLayer.transform.GetChild (randomPosition).gameObject.transform;
	}
}
