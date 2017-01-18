using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;

	private Animator animator;
	public int attackDamage;

	private Transform player;

	void Start(){
		animator = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		} 
		else if (Input.GetKey (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		} 
		else if (Input.GetKey (KeyCode.Period)) {
			animator.SetTrigger("enemyAttack");
		} 
	}
	protected override void HandleCollision<T>(T component){
		Player player = component as Player;
		player.TakeDamage (attackDamage);
	}

}
