using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Player : MonoBehaviour
{
	[Header("Bullet actions and controls")]
	[Tooltip("How far the bullet goes")]
	public float range = 100f;
	// [Tooltip("The bullet prefab")]
	// [SerializeField]
	// private GameObject bulletPrefab;
	// [Tooltip("Bullet speed")]
	// [SerializeField]
	// private float bulletSpeed;
	[Tooltip("Bullet spawn point")]
	[SerializeField]
	private Transform bulletPoint;
	private StarterAssetsInputs input;
	void Start()
	{
		// get the component from the parent of the gun
		input = transform.root.GetComponent<StarterAssetsInputs>();
	}

	void Update()
	{
		if(input.shoot) {
			Shoot();
			input.shoot = false;
		}
	}
	private void Shoot()
	{
		RaycastHit hit;
		Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range);
		//Visualize the ray
		Debug.DrawRay(bulletPoint.transform.position,bulletPoint.transform.forward * hit.distance, Color.red);
		Debug.Log("Raycast sent" + hit.transform.name);
		// instantiate the bullet
		// GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position,transform.rotation);
		// Add force and direction
		// bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		//destroy the bullet after a while
		// Destroy(bullet, 1);
	}
}
