using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

	public static EnemyManager Instance;
	
	//prefabs so I can instantiate them
	public GameObject enemyPrefab;
	public GameObject bonusPrefab;
	public GameObject boostPrefab;
	public GameObject heartPrefab;
	
	//formation so I can move all as a whole
	public GameObject enemyFormation;
	
	//declaring instances of my classes so I can instantiate in for loop
	public Enemy e;
	public Bonus b;
	public Boost z;
	public Heart h;
	
	public float speed;
	//dynamic enemy count can be changed in inspector and the list size adjusts
	public int enemyCount = 5;

	public int healthSpawnChance;
	
	//value of the bonus
	public int bonusValue = 10;

	public int waveTracker;
	
	//start location of the formation
	public Vector3 formationSpawn;
	
	//making my lists to store enemies (lists are dynamic, arrays are not)
	private List<Enemy> enemyList;
	private List<Bonus> bonusList;

	public Turret turretScript;

	void Start ()
	{
		Instance = this;
		
		enemyList = new List<Enemy>();
		
		formationSpawn = new Vector3(10, 10);
		
		//centers our formation relative to children
		enemyFormation.transform.localPosition = Vector3.zero;
		bonusPrefab.SetActive(true);
	}
	
	public void SpawnEnemy()
	{
		for (int i = 0; i <= enemyCount; i++)
		{	
			e = new Enemy();	
			enemyList.Add(e);
		}

		for (int i = 0; i <= Bonus.frequency; i++)
		{
			b = new Bonus();
			//didnt need to add to a list. why?
		}
		
		for (int i = 0; i <= Boost.frequency; i++)
		{
			z = new Boost();
			//didnt need to add to a list. why?
		}

		if (turretScript.currentHealth < 50)
		{

			healthSpawnChance = Random.Range(0, 2);
			Debug.Log(healthSpawnChance);

			if (healthSpawnChance == 1)
			{
				h = new Heart();
			}
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
			waveTracker++;
			print("wave = " + waveTracker);
			print("speed = " + speed);
		}

		if (waveTracker >= 5)
		{
			speed *= 1.1f;
			waveTracker = 0;
		}
		
		MoveEnemyFormation();
	}
}
