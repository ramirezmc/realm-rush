using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
	[SerializeField] Transform weapon;
	[SerializeField] float weaponRange = 15f;
	[SerializeField] ParticleSystem weaponFire;
	Transform target;
	
	void Start()
	{
		var weaponEmission = weaponFire.emission;
		weaponEmission.enabled = false;
	}
    void Update()
	{
		FindCloseTarget();
		AimWeapon();
	}
    
	void FindCloseTarget()
	{
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		Transform closestTarget = null;
		float maxDistance = weaponRange;
		
		foreach(Enemy enemy in enemies)
		{
			float targetDistance = Vector3.Distance(this.transform.position, enemy.transform.position);
			if(targetDistance < maxDistance)
			{
				closestTarget = enemy.transform;
				maxDistance = targetDistance;
			}
		}
		target = closestTarget;
	}
    
	void AimWeapon()
	{
		if (target != null)
		{
			float targetDistance = Vector3.Distance(transform.position, target.position);
			weapon.LookAt(target);
			if (targetDistance < weaponRange)
				{
					FireWeapon(true);
				}
		}
		else
		{
			FireWeapon(false);
		}
	}
	
	void FireWeapon(bool state)
	{
		var weaponEmission = weaponFire.emission;
		weaponEmission.enabled = state;
	}
}
