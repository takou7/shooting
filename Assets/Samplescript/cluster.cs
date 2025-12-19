using UnityEngine;
using System.Collections;

public class Cluster : MonoBehaviour {
    public float speed = 1f;
    public float pank = 10f;
    public GameObject clusterPrefab0;

	float fallSpeed;
	
	
	void Start () {
		this.fallSpeed = speed;
        Invoke("SpawnClusterPrefab", pank);
	}
	
	void Update () {
		transform.Translate(0, -fallSpeed * Time.deltaTime, 0, Space.World);

		if (transform.position.y < -8 || transform.position.y > 5 ||
            transform.position.x < -4 || transform.position.x > 4 ) {
			Destroy (gameObject);
		}		
	}
	void SpawnClusterPrefab() {
                float angleStep = 360f / 8; // 8方向に発射するための角度ステップ
        float angle = 0f;

        for (int i = 0; i < 8; i++) {
            float dirX = Mathf.Sin((angle * Mathf.PI) / 180f);
            float dirY = Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 moveVector = new Vector3(dirX, dirY, 0f);
            Vector2 direction = moveVector;

            GameObject cluster0 = Instantiate(clusterPrefab0, transform.position, Quaternion.identity);
            cluster0.GetComponent<Cluster0>().SetDirection(direction);

            angle += angleStep;
        }
        Destroy (gameObject);
    }
	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("rocket")) {
            Destroy(coll.gameObject); 
			Destroy (gameObject);
        }
    }
}

