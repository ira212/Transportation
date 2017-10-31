using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject cubePrefab;
	Vector3 cubePosition;
	GameObject activeCube;
	int airplaneX, airplaneY;
	GameObject[,] grid;
	int gridX, gridY;
	bool airplaneActive;


	// Use this for initialization
	void Start () {
		gridX = 16;
		gridY = 9;
		grid = new GameObject[gridX, gridY];

		for (int y = 0; y < gridY; y++) {
			for (int x = 0; x < gridX; x++) {
				cubePosition = new Vector3 (x * 2, y * 2, 0);
				grid[x,y] = Instantiate (cubePrefab, cubePosition, Quaternion.identity);
				grid [x, y].GetComponent<CubeController> ().myX = x;
				grid [x, y].GetComponent<CubeController> ().myY = y;
			}
		}

		// airplane starts in the upper left
		airplaneX = 0;
		airplaneY = 8;
		grid [airplaneX, airplaneY].GetComponent<Renderer> ().material.color = Color.red;
		airplaneActive = false;

		
	}
	
	public void ProcessClick (GameObject clickedCube, int x, int y) {
		// Was the airplane clicked?
		if (x == airplaneX && y == airplaneY) {
			if (airplaneActive) {
				// deactivate it
				airplaneActive = false;
				clickedCube.transform.localScale /= 1.5f;
			} else {
				// activate it
				airplaneActive = true;
				clickedCube.transform.localScale *= 1.5f;
			}
		}
		// if the player clicked the sky (not an airplane)
		else {
			if (airplaneActive) {
				// remove the airplane from it's old spot
				grid[airplaneX, airplaneY].GetComponent<Renderer>().material.color = Color.white;
				grid[airplaneX, airplaneY].transform.localScale /= 1.5f;

				// put the airplane in it's new spot
				airplaneX = x;
				airplaneY = y;
				grid[x, y].GetComponent<Renderer>().material.color = Color.red;
				grid[x, y].transform.localScale *= 1.5f;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
