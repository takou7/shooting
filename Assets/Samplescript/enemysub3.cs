using System.Collections;
using UnityEngine;

public class Enemy4 : MonoBehaviour {
    public float normalSpeed = 2f;
    public float boostedSpeed = 1f;
    public Vector2 minBounds = new Vector2(-3, -4.5f); // 移動範囲の最小値を指定
    public Vector2 maxBounds = new Vector2(2, 4.5f);   // 移動範囲の最大値を指定
    public int enemy4HP = 80;  // enemyの体力
    public GameObject BombPrefab;
    public GameObject enemy;

    private Vector3 movementDirection;
    public float changeDirectionTime = 3f; // 方向を変える時間間隔
    private float timeSinceLastChange = 0f;
    private EnemyManager4 enemyManager4;

    void Start() {
        // 初期移動方向を設定
        ChangeDirection();
        enemyManager4 = FindObjectOfType<EnemyManager4>(); // EnemyManagerを見つける
    }

    void Update() {
        // 前回の方向変更からの経過時間を更新
        timeSinceLastChange += Time.deltaTime;

        // 一定時間ごとに方向を変更
        if (timeSinceLastChange >= changeDirectionTime) {
            ChangeDirection();
            timeSinceLastChange = 0f;
        }

        // 移動を適用
        float moveSpeed = (Random.value > 0.5f) ? boostedSpeed : normalSpeed;
        Vector3 newPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        // 移動範囲を制限
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        // 新しい位置を設定
        transform.position = newPosition;

        if (enemy4HP <= 0)
        {
            // 敵が破壊される
            enemyManager4.StartCoroutine(enemyManager4.RespawnEnemy());
            Destroy(gameObject);
            Genbomb ();
        }
    }
        void Genbomb () {
		if (enemy != null && Random.value > 0.3f) {
			// enemyの位置を取得し、そこから岩を生成する
			Vector3 enemyPosition = enemy.transform.position;
			Instantiate(BombPrefab, enemyPosition, Quaternion.identity);
		}
	}

    void ChangeDirection() {
        // ランダムな移動方向を設定
        float randomAngle = Random.Range(0f, 360f);
        float radian = randomAngle * Mathf.Deg2Rad;
        movementDirection = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("bullet")) {
            Destroy(collision.gameObject); // 弾を破壊
            enemy4HP -= 1;
        }
    }
}