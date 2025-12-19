using UnityEngine;
using System.Collections;
public class RocketController : MonoBehaviour {
    public float normalSpeed = 6.5f;
    public float boostedSpeed = 2.2f;
    public GameObject bulletPrefab;
    public float bulletDelay = 0.1f; 
    private bool isShooting = false;
    public Vector2 minBounds = new Vector2(-3, -4.5f); // 移動範囲の最小値を指定
    public Vector2 maxBounds = new Vector2(3, 4.5f);   // 移動範囲の最大値を指定
    public float powerminus = 40f;
    public GameObject bombPrefab;
    public int bombCount = 3;
    private int power = 1;
    

    void Start() {
        // 最初のパワーが条件を満たす場合にコルーチンを開始
        StartCoroutine(Powerminus());
    }

    IEnumerator Powerminus() {
        while (true) { // 無限ループにして常に動作するようにする
            if (power > 1) {
                yield return new WaitForSeconds(powerminus); // 指定された時間だけ待機
                power -= 1; // パワーを1減少させる
                Debug.Log("Power decreased: " + power);
            } else {
                yield return null; // パワーが1以下の時は1フレーム待機
            }
        }
    }

    void Update () {
        // 現在の移動速度を決定
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? boostedSpeed : normalSpeed;
        Vector3 newPosition = transform.position;

        if (Input.GetKey(KeyCode.A)) {
            newPosition.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            newPosition.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W)) {
            newPosition.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            newPosition.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.M) && !isShooting) {
            StartCoroutine(ShootContinuously());
		}

        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        // 新しい位置を設定
        transform.position = newPosition;
        
        if (Input.GetKeyDown(KeyCode.Space) && bombCount > 0)
        {
            UseBomb();
        }
    }

    void UseBomb()
    {  
        if (bombPrefab != null || bombCount > 0 )
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            bombCount -= 1;
        }
    }

    IEnumerator ShootContinuously() {
        isShooting = true;
        while (Input.GetKey(KeyCode.M)) {
            if (power == 1){
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(bulletDelay);
            }
            else if (power == 2){
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z) , Quaternion.identity);
                yield return new WaitForSeconds(bulletDelay);
            }
            else if (power == 3) {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z) , Quaternion.identity);
                yield return new WaitForSeconds(bulletDelay);
            }
            else if (power == 4) {
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z) , Quaternion.identity);
                yield return new WaitForSeconds(bulletDelay);
            }
             else{
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z) , Quaternion.identity);
                Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z) , Quaternion.identity);
                yield return new WaitForSeconds(bulletDelay);
            }
        }
        isShooting = false;
    }
    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.CompareTag("power")) {
            power += 1;
            Destroy(coll.gameObject); 			
        }	
        else if (coll.gameObject.CompareTag("bomb")) {
            bombCount += 1;
            Destroy(coll.gameObject); 
        }
    }
}


