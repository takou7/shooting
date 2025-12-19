using UnityEngine;

public class Power : MonoBehaviour {
    private void Update() {
        // オブジェクトの位置を取得
        Vector3 position = transform.position;

        // オブジェクトが指定された範囲外に出た場合に破壊
        if (position.y < -5 ) {
            Destroy(gameObject);
        }
    }
}
