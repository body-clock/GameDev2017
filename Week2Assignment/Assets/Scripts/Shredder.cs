using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour

{
	//simple script for destroying gameobjects once they leave the screen
	//and collide with our shredder
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy") || other.CompareTag("Bonus") || other.CompareTag("Boost") || other.CompareTag("Heart"))
		{
			Destroy(other.gameObject);
		}
	}
}
	