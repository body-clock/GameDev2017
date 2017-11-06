using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
	public static AudioDirector instance;
	
	private AudioSource ads;

	public AudioClip boost;
	public AudioClip money;
	public AudioClip hit;
	public AudioClip heart;

	// Use this for initialization
	void Start ()
	{
		instance = this;
		ads = GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);
	}

	public void PlayBoostSound()
	{
		ads.PlayOneShot(boost);
	}
	
	public void PlayMoneySound()
	{
		ads.PlayOneShot(money);
	}
	
	public void PlayHitSound()
	{
		ads.PlayOneShot(hit);
	}

	public void playHealthSound()
	{
		ads.PlayOneShot(heart);
	}
}
