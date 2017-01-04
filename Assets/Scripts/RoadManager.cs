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
	public GameObject[] otherRoads;
	public float otherRoadChance = 0f;
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
				instantiatedRoad.SetActive (false);

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
		foreach (float key in loadedRoads.Keys) {
			GameObject o = loadedRoads [key];
			Vector3 newPos = o.transform.localPosition;

			newPos.y -= Time.deltaTime * velocity;
			o.transform.localPosition = newPos;

			if (Mathf.Abs (o.transform.localPosition.y) > Camera.main.orthographicSize + 1)
				o.SetActive (false);
			else
				o.SetActive (true);
		}
	}

	private GameObject getInstantiatedRoad (GameObject selectedRoad, int i)
	{
		GameObject instantiatedRoad = null;

		Transform loadedRoadTransform = (loadedRoads.Count == 0) ? startArea : loadedRoads [loadedRoads.Keys [i - 1]].transform;
		int tilesDistance = selectedRoad.GetComponent<RoadStat> ().tileDistance;
		Vector2 vector = new Vector2 (loadedRoadTransform.localPosition.x, loadedRoadTransform.position.y + tilesDistance);
		instantiatedRoad = (GameObject)Instantiate (selectedRoad, vector, Quaternion.identity);
		instantiatedRoad.transform.parent = roadHolder.transform;

		return instantiatedRoad;
	}

	private GameObject getRoad ()
	{
		if (otherRoads.Length == 0 || Random.value > otherRoadChance) {
			return mainRoad;
		} else {
			return getRandomRoad ();
		}
	}

	private GameObject getRandomRoad ()
	{
		GameObject road = null;

		int randomIndex = Random.Range (0, otherRoads.Length);
		road = otherRoads [randomIndex];

		return road;
	}
}
