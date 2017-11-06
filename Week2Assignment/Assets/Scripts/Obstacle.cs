using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle {
	
	public int xCoord;
	public int yCoord;

	public GameObject visual;

	public Obstacle(GameObject prefab, int frequency)
	{
		//casting a float as an int
		xCoord = (int) UnityEngine.Random.Range(-7f,7f);
		yCoord = (int) UnityEngine.Random.Range(5f,15f);

		GameObject.Instantiate(prefab, new Vector3(xCoord, yCoord), Quaternion.identity);
	}
}
