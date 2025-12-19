using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour
{
    void Start()
    {
        {
            StartCoroutine(DestroyObj());
        }
    }

    IEnumerator DestroyObj()
    {
        // ゲーム内のすべての"rock"タグを持つオブジェクトを取得
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("rock");
        GameObject[] clusters = GameObject.FindGameObjectsWithTag("cluster");

        // 中心からの距離に基づいて岩をソート
        System.Array.Sort(rocks, (a, b) =>
        {
            float distanceA = Vector3.Distance(transform.position, a.transform.position);
            float distanceB = Vector3.Distance(transform.position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });
        System.Array.Sort(clusters, (a, b) =>
        {
            float distanceA = Vector3.Distance(transform.position, a.transform.position);
            float distanceB = Vector3.Distance(transform.position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });


        // ソートされた岩を順番に破壊
        foreach (GameObject rock  in rocks)
        {
            Destroy(rock);
            yield return new WaitForSeconds(0.003f); // 0.007秒の遅延
        }
        foreach (GameObject cluster  in clusters)
        {
            Destroy(cluster);
            yield return new WaitForSeconds(0.003f);
        }
    }
}
