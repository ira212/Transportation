using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject cubePrefab;
	Vector3 cubePosition;
	public static GameObject activeCube;

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
