using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float height = 10.0f;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        populate_start();
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
    }

    private void populate_start()
    {
        for (int i =0; i< 10; i++)
        {
            Spawn(swarmerPrefab);
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Spawn(enemy);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    private void Spawn(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-20f, 20), height, Random.Range(-20f, 20f)), Quaternion.identity);
    }
}