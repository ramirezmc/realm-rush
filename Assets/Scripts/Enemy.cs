using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
	[SerializeField]int goldReward = 25;
	[SerializeField]int goldPenalty = 25;
	Bank bank;
	
    void Start()
    {
	    bank = FindObjectOfType<Bank>();
    }
    
	public void RewardGold()
	{
		if(bank == null){ return; }
		bank.DepositMoney(goldReward);
	}
    
	public void StealGold()
	{
		if(bank == null){ return; }
		bank.WithdrawMoney(goldPenalty);
	}
}
