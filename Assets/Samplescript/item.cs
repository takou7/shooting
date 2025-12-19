using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public GameObject PowerPrefab;
    public GameObject BombPrefab2;
    public float powertime = 10f;
    public float bombtime = 30f;
    
    void Start () {
        InvokeRepeating("GenPower", powertime, powertime);
        InvokeRepeating("GenBomb", bombtime, bombtime);
    }

	void Update () {
        
        if (transform.position.y < -5 || transform.position.y > 8 ||
            transform.position.x < -4 || transform.position.x > 4  ) 
        {
			Destroy (gameObject);
		}		
	}
    void GenPower() {
        Instantiate (PowerPrefab, new Vector3 (-3.3f + 5 * Random.value, 7, 0), Quaternion.identity);
    }
       void GenBomb() {
        Instantiate (BombPrefab2, new Vector3 (-3.3f + 5 * Random.value, 7, 0), Quaternion.identity);
    }
}