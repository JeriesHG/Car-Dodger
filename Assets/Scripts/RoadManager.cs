using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
	[Header ("Initial Settings")]
	public Transform startArea;
	public GameObject roadHolder;
	public int roadLength;

	[Header ("Road Settings")]
	public GameObject mainRoad;
	public GameObject endRoad;

	[System.Serializable]
	public struct OtherRoad
	{
		public GameObject road;
		public float chance;
	}

	public OtherRoad[] otherRoads;

	private SortedList<float, GameObject> loadedRoads;

	[Header ("Movement")]
	public float velocity;
	public float distance;

	void Start ()
	{
		initializeRoads ();
	}

	private void initializeRoads ()
	{
		loadedRoads = new SortedList<float, GameObject> ();

		for (int i = 0; i < roadLength; i++) {

			GameObject selectedRoad = getRoad ();
			GameObject instantiatedRoad = getInstantiatedRoad (selectedRoad, i);

			float key = instantiatedRoad.transform.localPosition.y;
			if (key > Camera.main.orthographicSize)
				instantiatedRoad.SetActive (true);

			loadedRoads.Add (key, instantiatedRoad);

			if (i + 1 == roadLength) {
				GameObject instatiatedEndRoad = getInstantiatedRoad (endRoad, i + 1);
				instatiatedEndRoad.SetActive (false);
				loadedRoads.Add (instatiatedEndRoad.transform.localPosition.y, instatiatedEndRoad);
			}
		}
	}

	void Update ()
	{
		distance += Time.deltaTime * velocity;

		Vector3 newPos = roadHolder.transform.localPosition;
		newPos.y -= Time.deltaTime * velocity;
		roadHolder.transform.localPosition = newPos;
	}

	private GameObject getInstantiatedRoad (GameObject selectedRoad, int i)
	{
		GameObject instantiatedRoad = null;

		int tilesDistance = 0;
		Transform loadedRoadTransform = null;
		if (loadedRoads.Count == 0) {
			loadedRoadTransform = startArea;
		} else {
			GameObject previousRoad = loadedRoads [loadedRoads.Keys [i - 1]];
			tilesDistance = (int)previousRoad.GetComponent<Tile2D.TileRoom2D> ().roomSize.y;
			loadedRoadTransform = previousRoad.transform;
		}

		Vector2 vector = new Vector2 (loadedRoadTransform.localPosition.x, loadedRoadTransform.localPosition.y + tilesDistance);
		instantiatedRoad = (GameObject)Instantiate (selectedRoad, vector, Quaternion.identity);
		instantiatedRoad.transform.parent = roadHolder.transform;

		return instantiatedRoad;
	}

	private GameObject getRoad ()
	{
		GameObject road = mainRoad;

		float randomValue = Random.value;
		foreach (OtherRoad e in otherRoads) {
			if (e.chance > randomValue) {
				road = e.road;
				break;
			}
		}

		return road;
	}

	private OtherRoad getRandomRoad ()
	{
		OtherRoad road = new OtherRoad ();

		int randomIndex = Random.Range (0, otherRoads.Length);
		road = otherRoads [randomIndex];

		return road;
	}
}
