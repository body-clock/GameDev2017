using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy
{

	public GameObject enemyVisual;
	public int xCoord;
	public int yCoord;
	public string name;
	public Transform enemyPos;

	public Vector3 screenPos;
	
	

	public Enemy()
	{
		//constructor - runs when we say "new"
		
		//casting a float as an int
		xCoord = (int) UnityEngine.Random.Range(-8f,8f);
		yCoord = (int) UnityEngine.Random.Range(5f,10f);

		//instantiating our visual with our prefab
		//setting the parent object to the formation object
		enemyVisual = GameObject.Instantiate(EnemyManager.Instance.enemyPrefab, new Vector3(xCoord, yCoord), Quaternion.identity);
		enemyVisual.transform.parent = EnemyManager.Instance.enemyFormation.transform;
	}
	
}
