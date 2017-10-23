using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart {

//visual representation of our enemy
	public GameObject heartVisual;
	//randomized coordinates in space
	public int xCoord;
	public int yCoord;

	public Heart()
	{
		//constructor - runs when we say "new"
		
		//casting a float as an int
		xCoord = (int) Random.Range(-7f,7f);
		yCoord = (int) Random.Range(5f,15f);

		//instantiating our visual with our prefab
		//setting the parent object to the formation object
		heartVisual = GameObject.Instantiate(EnemyManager.Instance.heartPrefab, new Vector3(xCoord, yCoord), Quaternion.identity);
		//parenting to the formation so we can move as a whole
		heartVisual.transform.parent = EnemyManager.Instance.enemyFormation.transform;
	}
}
