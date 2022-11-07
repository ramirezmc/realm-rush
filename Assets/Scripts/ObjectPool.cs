using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] GameObject enemyPrefab;
	[SerializeField][Range(0,50)] int poolSize = 5;
	[SerializeField][Range(0.5f, 10f)] float spawnTimer = 1f;
	
	GameObject[] pool;
	
	protected void Awake()
	{
		PopulatePool();
	}
	
	void Start()
	{
		Transform parent = transform;
	    StartCoroutine (InstantiateEnemy());
    }
    
	void PopulatePool()
	{
		pool = new GameObject[poolSize];
		
		for (int i = 0; i < pool.Length; i++)
		{
			pool[i] = Instantiate(enemyPrefab, gameObject.transform);
			pool[i].SetActive(false);
		}
	}
	
	IEnumerator InstantiateEnemy()
	{
		while(true)
		{
			for (int i = 0; i < pool.Length; i++)
			{
				pool[i].SetActive(true);
				yield return new WaitForSeconds(spawnTimer);
			}
		}
	}
}
