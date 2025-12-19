using UnityEngine;
using System.Collections;

public class RockGenerator3 : MonoBehaviour {
	public GameObject Rockhoming; 
	public GameObject enemy; // enemyオブジェクトの参照
	public float time1 = 0.5f; // 初回の岩生成までの待機時間
	public float time2 = 5f; // 以降の岩生成間隔時間
	public float time3 = 0.6f;
	void Start () {
		InvokeRepeating("GenRockRepeated", time1, time2); // 一定間隔でGenRockメソッドを呼び出す
	}
	void GenRockRepeated(){
			Invoke("GenRock2", 0f); 
        	Invoke("GenRock2", time3); 
        	Invoke("GenRock2", 2 * time3); 
			Invoke("GenRock2", 3 * time3); 
			Invoke("GenRock2", 4 * time3); 
	    }

	void GenRock2 () {
		if (enemy != null) {
			// enemyの位置を取得し、そこから岩を生成する
			Vector3 enemyPosition = enemy.transform.position;
			Instantiate(Rockhoming, enemyPosition, Quaternion.identity);
		}
    }
}

