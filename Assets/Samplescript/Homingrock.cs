using UnityEngine;

public class RocketDirectionRockController : MonoBehaviour
{
    public float speed = 5f;
    private Transform rocketTransform; // ロケットのTransform

    private Vector3 direction; // 岩の移動方向

    void Start()
    {
        GameObject rocket = GameObject.FindGameObjectWithTag("rocket");
        if (rocket != null)
        {
            rocketTransform = rocket.transform;
            // ロケットの方向に向かって移動するための方向ベクトルを計算する
            direction = (rocketTransform.position - transform.position).normalized;
        }
        else
        {
            Debug.LogError("Rocket not found!");
            Destroy(gameObject); // 岩を破壊してスクリプトを無効にする
        }
    }

    void Update()
    {
        // ロケットの方向に向かって移動する
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < -5 || transform.position.y > 5 ||
            transform.position.x < -4 || transform.position.x > 4 ||
            speed == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rocket"))
        {
            Destroy(collision.gameObject); // ロケットを破壊
            Destroy(gameObject); // 岩を破壊
        }
    }
}