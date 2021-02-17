using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Spawn());
        InvokeRepeating(nameof(Spawn), 0f, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.parent = transform;

        // yield return new WaitForSeconds(1f);
    }
}
