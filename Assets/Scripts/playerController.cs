using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;

	private Animator animator;
	private int playerHealth = 50;

	
	void Start(){
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
		} else if (Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		} 
		else if (Input.GetKey (KeyCode.W)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		} 
		else if (Input.GetKey (KeyCode.E)) {
			animator.SetTrigger("playerChop");
		} 
	}

	private void OnTriggerEnter2D(Collider2D objectPlayerCollideWith){
		if (objectPlayerCollideWith.tag == "Soda") {
			Debug.Log("Collided with Soda");
			objectPlayerCollideWith.gameObject.SetActive(false);
		}
		else if (objectPlayerCollideWith.tag == "Fruit") {
			Debug.Log("Collided with Fruit");
			objectPlayerCollideWith.gameObject.SetActive(false);
		}

	}
	public void TakeDamage(int damageRecieved){
		playerHealth -= damageRecieved;
		animator.SetTrigger ("playerHit");
	}

}
