using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour 
{
	public bool bossAwake = false;
	public bool inBattle = false;
	public bool attacking = false;

	public float idleTimer = 0.0f;
	public float idleWaitTime = 10.0f;

	public float attackTimer = 0.0f;
	public float attackWaitTime = 2.0f;
	public int attackCount = 1;

	private Animator anim;
	private BossHealth bossHealth;

	private BoxCollider handTrigger_L;
	private BoxCollider handTrigger_R;
	
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponentInChildren<Animator>();
		bossHealth = GetComponentInChildren<BossHealth>();
		handTrigger_L = GameObject.Find ("HandTrigger_L").GetComponent<BoxCollider>();
		handTrigger_R = GameObject.Find ("HandTrigger_R").GetComponent<BoxCollider>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bossAwake)
		{
			print ("Boss is awake!");
			//Play Intro animation
			anim.SetBool("bossAwake", true);

			if(inBattle)
			{
				if(!attacking)
				{
					idleTimer += Time.deltaTime;
				}
				else
				{
					idleTimer = 0.0f;
					attackTimer += Time.deltaTime;
					if(attackTimer >= attackWaitTime)
					{
						attacking = false;

						attackTimer = 0.0f;
						print ("BOSS SMASH!");
						handTrigger_L.collider.enabled = true;
						handTrigger_R.collider.enabled = true;
					}
				}

				if(idleTimer >= idleWaitTime)
				{
					//Attack
					print ("Boss is attacking!");
					attacking = true;
					idleTimer = 0.0f;
				}
			}
			else
			{
				idleTimer = 0.0f;
			}
		}
		
	}
}
