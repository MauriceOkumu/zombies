using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField]
	private float hitPoints = 100f;
	
	//call this method in Shoot()
	public void TakeDamage(float damage) 
	{
		hitPoints -= damage;
		DeadPlayer();
	}
	
	private void DeadPlayer() 
	{
		if (hitPoints <= 0) 
		{
			//Play dead music, animations, ete
			Destroy(gameObject);
		}
	}
}
