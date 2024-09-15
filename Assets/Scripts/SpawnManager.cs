using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] points;

    public bool gameOver = false;
    private float spawnInterval = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];

            Instantiate(enemy, ChooseRandomSpawnPos(), enemy.transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }

    }

    public Vector3 ChooseRandomSpawnPos()
    {
        int pointIndex = Random.Range(0, 4);
        int adjacentPointIndex = pointIndex + (int)Random.Range(-1, 1);
        if (adjacentPointIndex > points.Length)
        {
            adjacentPointIndex = points.Length;
        }
        else if (adjacentPointIndex < 0)
        {
            adjacentPointIndex = 0;
        }

        GameObject firstPoint = points[pointIndex];
        GameObject secondPoint = points[adjacentPointIndex];

        return new Vector3(Random.Range(firstPoint.transform.position.x, secondPoint.transform.position.x),
         Random.Range(firstPoint.transform.position.y, secondPoint.transform.position.y),
         Random.Range(firstPoint.transform.position.z, secondPoint.transform.position.z));

    }


}
