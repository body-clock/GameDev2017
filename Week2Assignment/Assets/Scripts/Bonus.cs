using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus {

    public GameObject bonusVisual;
    public int xCoord;
    public int yCoord;
    public string name;
    public Transform enemyPos;

    public Vector3 screenPos;

    public static int frequency;

    public int scoreBonus = 10;
	

    public Bonus()
    {
        //constructor - runs when we say "new"

        frequency = (int) UnityEngine.Random.Range(1f, 4f);
        Debug.Log(frequency);
		
        //casting a float as an int
        xCoord = (int) UnityEngine.Random.Range(-8f,8f);
        yCoord = (int) UnityEngine.Random.Range(5f,10f);

        //instantiating our visual with our prefab
        //setting the parent object to the formation object
        bonusVisual = GameObject.Instantiate(EnemyManager.Instance.bonusPrefab, new Vector3(xCoord, yCoord), Quaternion.identity);
        bonusVisual.transform.parent = EnemyManager.Instance.enemyFormation.transform;
    }
    

}
