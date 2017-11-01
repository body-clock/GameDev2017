using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public AudioManager instance;

	void Start ()
	{
	//singleton pattern so we only have 1 music player
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
