using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetLocator))] 
public class Ballista : MonoBehaviour
{
	[SerializeField]int cost = 50;
	[SerializeField][Range(0.1f, 5f)] float buildTimer = 1f;
	[SerializeField]GameObject ballistaTop;
	[SerializeField]GameObject ballistaBase;
	
	protected void Start()
	{
		ballistaTop.gameObject.SetActive(false);
		ballistaBase.gameObject.SetActive(false);
		StartCoroutine(BuildBallista());
	}
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
	
	IEnumerator BuildBallista()
	{
		yield return new WaitForSeconds(buildTimer);
		ballistaBase.SetActive(true);
		yield return new WaitForSeconds(buildTimer);
		ballistaTop.SetActive(true);
	}
}
