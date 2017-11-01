using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour 
{
	
	//simple script to destroy the particle systems after they finish running
	private ParticleSystem ps;
 
	public void Start() 
	{
		ps = GetComponent<ParticleSystem>();
	}
 
	public void Update() 
	{
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
