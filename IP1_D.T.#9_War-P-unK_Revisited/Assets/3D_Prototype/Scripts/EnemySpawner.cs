using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public float xScaleControl = 3f;
    public float yScaleControl = 3f;
    public float zScaleControl = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1.5f);
    }

    void SpawnEnemy()
    {
        GameObject EnemyClone = Instantiate(Enemy);
        EnemyClone.transform.localScale = new Vector3(Random.Range(1f, xScaleControl), Random.Range(1f, yScaleControl), Random.Range(1f, zScaleControl));
        EnemyClone.transform.position = GetComponentInParent<Transform>().position;
        EnemyClone.transform.position += new Vector3(Random.Range(-5f, 5f), Random.Range(-2f, 4f));
        EnemyClone.SetActive(true);
    }
}
