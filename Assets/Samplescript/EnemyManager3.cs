using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class EnemyManager3 : MonoBehaviour {
    public GameObject Enemy3; // 敵のプレハブ
    public float assault = 15f;
    public float revivaltime = 30f;
    Vector3 fixedPosition = new Vector3(-2, 5, 0);
     
    void Start(){
        Invoke("appear",assault);
    }
    void appear(){
        Instantiate(Enemy3, fixedPosition, Quaternion.identity);
    }

    public IEnumerator RespawnEnemy() {
       
        // 30秒待機
        yield return new WaitForSeconds(revivaltime);
        
        // 敵を再生成
        Instantiate(Enemy3, fixedPosition, Quaternion.identity);
    }
}
