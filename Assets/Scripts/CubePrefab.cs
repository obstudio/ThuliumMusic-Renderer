using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.down * 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetDuration (double dur) {
		transform.localScale = new Vector3(1, (float)dur * 5, 1);
	}
}
