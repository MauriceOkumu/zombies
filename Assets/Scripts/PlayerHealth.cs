using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] float hitPoints = 3f;
  
	
	//call this method in Shoot()
	public void TakeDamage(float damage) 
	{
		hitPoints -= damage;
		Debug.Log("Attacked by the enemy :" + hitPoints);
		// DeadPlayer();
		if (hitPoints <= 0) 
		{
			GetComponent<DeathHandler>().HandleDeath();
			//Play dead music, animations, ete
			// Destroy(gameObject);
		}
	}
	
	private void DeadPlayer() 
	{
		if (hitPoints <= 0) 
		{
			GetComponent<DeathHandler>().HandleDeath();
			//Play dead music, animations, ete
			// Destroy(gameObject);
		}
	}
}
