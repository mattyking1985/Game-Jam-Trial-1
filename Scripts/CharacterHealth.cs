﻿using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour 
{
	public int health = 3;
	private CharacterMovement characterMovement;
	public float timer;
	public float waitTime = 2.0f;
	public ParticleSystemRenderer aura;
	private Color auraColor;
	Animator anim;

	// Use this for initialization
	void Awake () 
	{
		characterMovement = GetComponent<CharacterMovement>();
		aura = GetComponent<ParticleSystemRenderer>();
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health == 3)
		{
			anim.SetInteger("life", 3);
			auraColor = new Color(0.0f, 1.0f, 1.0f, 0.05f);
			aura.material.SetColor("_TintColor", auraColor);
		}

		if(health == 2)
		{
			anim.SetInteger ("life", 2);
			auraColor = new Color(1.0f, 1.0f, 0.0f, 0.05f);
			aura.material.SetColor("_TintColor", auraColor);
		}

		if(health == 1)
		{
			anim.SetInteger("life", 1);
			auraColor = new Color(1.0f, 0.0f, 0.0f, 0.05f);
			aura.material.SetColor("_TintColor", auraColor);
		}

		if(health == 0)
		{
			characterMovement.enabled = false;
			LevelReset();
		}
	
	}

	void LevelReset()
	{
		timer += Time.deltaTime;

		if(timer >= waitTime)
		{
			Application.LoadLevel(0);
		}
	}
}
