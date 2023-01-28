using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Player : MonoBehaviour
{
	[Header("Bullet actions and controls")]
	[Tooltip("How far the bullet goes")]
	public float range = 100f;
	
	[Tooltip("The damage the bullet does")]
	public float damage = 1f;
	// [Tooltip("The bullet prefab")]
	// [SerializeField]
	// private GameObject bulletPrefab;
	// [Tooltip("Bullet speed")]
	// [SerializeField]
	// private float bulletSpeed;
	[Tooltip("Bullet/ray spawn point")]
	[SerializeField]
	private Transform bulletPoint;
	
	[Tooltip("Weapon muzzleflash")]
	[SerializeField]
	private ParticleSystem muzzleflash;
	
	[Tooltip("Projectile hit effect")]
	[SerializeField]
	private GameObject hitEffect;
	
	[Tooltip("Ammo slot ")]
	[SerializeField]
	public Ammo ammoSlot;
	
	[Tooltip("Ammo type ")]
	[SerializeField]
	private AmmoType ammoType;
	
	[Tooltip("Delay between shots for different guns ")]
	[SerializeField]
	private float delayTime;
	
	bool canShoot = true;
	
	private StarterAssetsInputs input;
	void Start()
	{
		// get the component from the parent of the gun
		input = transform.root.GetComponent<StarterAssetsInputs>();
	}
	private void OnEnable() {
		canShoot = true;
	}

	void Update()
	{
		if(input.shoot && canShoot) {
			StartCoroutine(Shoot());
			input.shoot = false;
		}
	}
	private void ProcessRaycast()
	{
		RaycastHit hit;
		
		
		if(Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range))
		{
		//Visualize the ray
		Debug.DrawRay(bulletPoint.transform.position,bulletPoint.transform.forward * hit.distance, Color.red);
		Debug.Log("Raycast sent" + hit.transform.name);
		PlayHitEffect(hit);
		} else 
	{
		return;
	}
	}
	
	private void PlayMuzzleflash()
	{
		muzzleflash.Play();
	}
	
	private void PlayHitEffect(RaycastHit hit) 
	{

			GameObject impact = Instantiate(hitEffect, hit.point,Quaternion.identity);
			Destroy(impact, 1);
		
	}
	
	IEnumerator  Shoot()
	{
		 canShoot = false;
		if(ammoSlot.AmmoRemaining(ammoType) > 0) 
		{
			
		ProcessRaycast();
		PlayMuzzleflash();
		ammoSlot.ReduceAmmo(ammoType);
		}
		// instantiate the bullet
		// GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position,transform.rotation);
		// Add force and direction
		// bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		//destroy the bullet after a while
		// Destroy(bullet, 1);
		
		//
		// EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
		// if target == null return;
		//target.TakeDamage(damage)
		yield return new WaitForSeconds(delayTime);
		canShoot = true;
	
	}
}
