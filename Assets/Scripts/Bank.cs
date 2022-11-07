using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
	[SerializeField] int startingBalance = 300;
	int currentBalance;
    
	public int CurrentBalance{get { return currentBalance;}}
	
	void Awake()
	{
		currentBalance = startingBalance;
	}
	
	public void DepositMoney(int amount)
	{
		currentBalance += Mathf.Abs(amount);
	}
	
	public void WithdrawMoney(int amount)
	{
		currentBalance -= Mathf.Abs(amount);
		if (CurrentBalance < 0 )
		{
			SceneManager.LoadScene(0);
		}
		else
		{
			return;
		}
	}
}
