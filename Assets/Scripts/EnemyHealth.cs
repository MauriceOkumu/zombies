using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to the zombie
public class EnemyHealth : MonoBehaviour
{
	[SerializeField]
	private float hitPoints = 10f;
	
	//call this method in Shoot()
	public void TakeDamage(float damage) 
	{
		hitPoints -= damage;
		DeadZombie(hitPoints);
	}
	
	private void DeadZombie(float dead) 
	{
		if (dead <= 0) 
		{
			//Play dead music, animations, ete
			Destroy(gameObject);
		}
	}
}
