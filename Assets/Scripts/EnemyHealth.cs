using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHitPoints = 5;
	[Tooltip("Add this amount to enemy hitpoint when enemy dies")]
	[SerializeField] int difficultyRamp = 1;
	int hitPoints;
	Enemy enemy;
	
	protected void Awake()
	{
		enemy = GetComponent<Enemy>();
	}
	
	protected void OnEnable()
	{
		hitPoints = maxHitPoints;
	}
	
	void OnParticleCollision(GameObject other)
	{
		if (hitPoints > 0)
		{
			hitPoints--;
		}
		else
		{
			gameObject.SetActive(false);
			enemy.RewardGold();
			maxHitPoints += difficultyRamp;
		}
	}
}
