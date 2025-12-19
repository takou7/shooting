using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	
	public float shot = 15f;
	void Update () {
		transform.Translate (0, shot * Time.deltaTime, 0);

		if (transform.position.y > 5) {
			Destroy (gameObject);
		}		
	}            //この下のやつをvoid updateの中に入れちゃダメ
     void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("enemy")) {
		GameObject.Find ("Canvas").GetComponent<UIController> ().AddScore ();
		Destroy (gameObject);
       }
	 }
}
