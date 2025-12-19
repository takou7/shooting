using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {
    public float speed1 = -10f;
    public float speed2 = 13f;

	float fallSpeed;
	float rotSpeed;
	float horizontalSpeed;


	void Start () {
		this.fallSpeed = speed1 + speed2  * Random.value;
		this.rotSpeed = 5f + 3f * Random.value;
		this.horizontalSpeed = (Random.value - 0.5f) * speed2 * 2/3;
	}
	
	void Update () {
		transform.Translate(horizontalSpeed * Time.deltaTime, -fallSpeed * Time.deltaTime, 0, Space.World);
		transform.Rotate(0, 0, rotSpeed);

		if (transform.position.y < -5 || transform.position.y > 5 ||
            transform.position.x < -4 || transform.position.x > 4  ||
			fallSpeed < 0.8f && fallSpeed > -0.8f ||
			horizontalSpeed < 0.8f && horizontalSpeed > -0.8f) {
			Destroy (gameObject);
		}		
	}
	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("rocket")) {
            Destroy(coll.gameObject); 
			Destroy (gameObject);
        }	
    }
}
