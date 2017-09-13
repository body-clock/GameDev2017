using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

	public static EnemyManager Instance;
	
	public GameObject enemyPrefab;
	public GameObject enemyFormation;
	
	public Enemy e;
	
	public int speed;
	public int enemyCount = 5;

	public Vector3 formationSpawn;

	private List<Enemy> enemyList;

	void Start ()
	{
		Instance = this;
		
		enemyList = new List<Enemy>();
		
		formationSpawn = new Vector3(10, 10);
		
		//centers our formation relative to children
		enemyFormation.transform.localPosition = Vector3.zero;
	}
	
	public void SpawnEnemy()
	{
		for (int i = 0; i <= enemyCount; i++)
		{	
			e = new Enemy();	
			enemyList.Add(e);
		}
		
	}

	public void MoveEnemyFormation()
	{
		//moves the formation downwards
		enemyFormation.transform.position += Vector3.down * speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		//populating the enemy formation with enemies
		if (enemyFormation.transform.childCount == 0)	
		{
			SpawnEnemy();
		}	
		
		MoveEnemyFormation();
	}
}
