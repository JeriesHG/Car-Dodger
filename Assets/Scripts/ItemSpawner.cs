using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

	public float spawnChance = 0.2f;
	public GameObject[] spawnObjects;

	private Tile2D.TileLayer2D roadLayer;
	private GameObject parentItemHolder;

	// Use this for initialization
	void Start ()
	{
		parentItemHolder = this.transform.parent.gameObject;
		if (spawnObjects != null && spawnChance > Random.value) {
			//grabs first layer, it should be the room layer
			roadLayer = GetComponent<Tile2D.TileRoom2D> ().roomLayers [0];
			Transform selectedTile = retrieveRandomPosition ();
			GameObject item = (GameObject)Instantiate (
				                  spawnObjects [Random.Range (0, spawnObjects.Length)], 
				                  new Vector3 (selectedTile.position.x, selectedTile.position.y),
				                  Quaternion.identity);

			item.transform.parent = parentItemHolder.transform.GetChild (0);
		}
	}

	private Transform retrieveRandomPosition ()
	{
		int randomPosition = Random.Range (0, roadLayer.transform.childCount);
		return roadLayer.transform.GetChild (randomPosition).gameObject.transform;
	}
}
