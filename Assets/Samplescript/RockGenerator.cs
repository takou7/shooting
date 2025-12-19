using UnityEngine;
using System.Collections;

public class RockGenerator : MonoBehaviour {

	public GameObject rockPrefab; // 岩のプレハブを参照するための変数
	public GameObject Rockhoming; 
	public GameObject clusterPrefab;
	public GameObject enemy; // enemyオブジェクトの参照
	public float time1 = 1f; // 初回の岩生成までの待機時間
	public float time2 = 0.7f; // 以降の岩生成間隔時間
	public float time3 = 10f;
	public float time4 = 3f;
	public float time5 = 0.4f;
	public float time6 = 10f;
	public float time7 = 4f;
	public float levelup = 20f;
	void Start () {
		InvokeRepeating("GenRock", time1, time2); // 一定間隔でGenRockメソッドを呼び出す
		InvokeRepeating("GenRock2Repeated", time3, time4);
		InvokeRepeating("GenRock3", time6, time7);
	}
	void GenRock2Repeated()
    {
		if (Time.time < levelup){
			Invoke("GenRock2", 0f); 
        	Invoke("GenRock2", time5); 
        	Invoke("GenRock2", 2 * time5); 
		}
		else {
			Invoke("GenRock2", 0f); 
        	Invoke("GenRock2", time5); 
        	Invoke("GenRock2", 2 * time5); 
			Invoke("GenRock2", 3 * time5); 
			Invoke("GenRock2", 4 * time5); 
		}
    }
	
	void GenRock () {
		if (enemy != null) {
			// enemyの位置を取得し、そこから岩を生成する
			Vector3 enemyPosition = enemy.transform.position;
			Instantiate(rockPrefab, enemyPosition, Quaternion.identity);
		}
	}
	void GenRock2 () {
		if (enemy != null) {
			// enemyの位置を取得し、そこから岩を生成する
			Vector3 enemyPosition = enemy.transform.position;
			Instantiate(Rockhoming, enemyPosition, Quaternion.identity);
		}
	}
	void GenRock3 () {
		if (enemy != null) {
			// enemyの位置を取得し、そこから岩を生成する
			Vector3 enemyPosition = enemy.transform.position;
			Instantiate(clusterPrefab, enemyPosition, Quaternion.identity);
		}
	}
}
