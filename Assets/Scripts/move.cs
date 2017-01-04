using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	
	public float speed = 0.11f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		float h = speed * Input.GetAxis("Horizontal");
    	float v = speed * Input.GetAxis("Vertical");

    	if(Input.anyKey)
    	this.transform.Translate(h,v, 0);
    
 
		
	}
}
