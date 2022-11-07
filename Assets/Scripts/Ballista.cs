using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetLocator))] 
public class Ballista : MonoBehaviour
{
	[SerializeField]int cost = 50;
	public bool CreateTower(Ballista ballista, Vector3 position)
	{
		Bank bank = FindObjectOfType<Bank>();
		if (bank == null)
		{
			return false;
		}
		if (bank.CurrentBalance >= cost)
		{
			Instantiate(ballista.gameObject, position, Quaternion.identity);
			bank.WithdrawMoney(cost);
			return true;
		}
		return false;
	}
}
