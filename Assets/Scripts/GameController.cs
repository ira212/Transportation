using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject cubePrefab;
	Vector3 cubePosition;
	GameObject activeCube;

	public void ProcessClick (GameObject clickedCube) {
		// turn the previously clicked cube white
		if (activeCube != null) {
			activeCube.GetComponent<Renderer> ().material.color = Color.white;
		}

		// now turn the currently clicked cube red
		clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		activeCube = clickedCube;
	}

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 16; i++) {
			cubePosition = new Vector3 (i*2, 0, 0);
			Instantiate (cubePrefab, cubePosition, Quaternion.identity);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
