using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy
{
	//visual representation of our enemy
	public GameObject enemyVisual;
	//randomized coordinates in space
	public int xCoord;
	public int yCoord;

	public Enemy()
	{
		//constructor - runs when we say "new"
		
		//casting a float as an int
		xCoord = (int) Random.Range(-7f,7f);
		yCoord = (int) Random.Range(5f,15f);

		//instantiating our visual with our prefab
		//setting the parent object to the formation object
		enemyVisual = GameObject.Instantiate(EnemyManager.Instance.enemyPrefab, new Vector3(xCoord, yCoord), Quaternion.identity);
		//parenting to the formation so we can move as a whole
		enemyVisual.transform.parent = EnemyManager.Instance.enemyFormation.transform;
	}

}
