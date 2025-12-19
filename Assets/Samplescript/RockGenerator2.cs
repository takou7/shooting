using UnityEngine;
using System.Collections;

public class RockGenerator2 : MonoBehaviour {

	public GameObject rockPrefab; // 岩のプレハブを参照するための変数

	public GameObject enemy; // enemyオブジェクトの参照
	public float time1 = 1f; // 初回の岩生成までの待機時間
	public float time2 = 0.08f; // 以降の岩生成間隔時間

	void Start () {
		InvokeRepeating("GenRock", time1, time2); // 一定間隔でGenRockメソッドを呼び出す
    }
	
	
	void GenRock () {
		if (enemy != null) {
			// enemyの位置を取得し、そこから岩を生成する
			Vector3 enemyPosition = enemy.transform.position;
			Instantiate(rockPrefab, enemyPosition, Quaternion.identity);
		}
	}
    
}

