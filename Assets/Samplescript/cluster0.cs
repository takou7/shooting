using UnityEngine;

public class Cluster0 : MonoBehaviour {
    public float speed = 5f; // 弾の速度

    private Vector2 direction;
	private float creationTime;
 

    public void SetDirection(Vector2 dir) {
        direction = dir.normalized; // 正規化して方向を設定
        creationTime = Time.time; 
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime); // 方向に応じて移動
            
        if (transform.position.y < -8 || transform.position.y > 5 ||
        transform.position.x < -4 || transform.position.x > 4 ) {
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
