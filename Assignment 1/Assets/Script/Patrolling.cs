using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
	public Transform[] waypoints;
	private int currentPoint = 0;
	public float damage = 25f;
	private Vector3 target;
	private Vector3 direction;
	private Transform playerTransf;
	private Vector3 playerDirection;
	public NavMeshAgent enemy;
	public Transform Player;
	GameObject player;

	void Start()
	{
		Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		player = GameObject.FindWithTag("Player");
		playerTransf = player.GetComponent<Transform>();
	}


	void Update()
	{
		playerDirection = playerTransf.transform.position - this.transform.position;
		playerDirection.y = 0;

		if (playerDirection.magnitude < 10 && playerTransf != null)
		{
			playerDirection.y = 0;
			this.transform.rotation = Quaternion.LookRotation(playerDirection);
			enemy.SetDestination(Player.position);



			if (currentPoint < waypoints.Length || playerTransf == null)
			{
				target = waypoints[currentPoint].position;
				direction = target - transform.position;
				if (direction.magnitude < 1)
					currentPoint++;

			}
			else
				currentPoint = 0;
		}
	}

	[SerializeField] private float knockbackStrength;
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
        {
			Rigidbody playerrb = col.collider.GetComponent<Rigidbody>();
			if (playerrb != null)
			{
				Damage();
				Vector3 knockback = transform.position - col.transform.position;
				knockback.y = 0;
				Rigidbody ourRB = transform.GetComponent<Rigidbody>();
				ourRB.AddForce(knockback.normalized * knockbackStrength, ForceMode.Impulse);
			}
		}
	}

	void Damage()
	{
		Player playerhp = player.GetComponent<Player>();
		playerhp.TakeDamage(damage);
		enemy.SetDestination(Player.position);

	}
}
