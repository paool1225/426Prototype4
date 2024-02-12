using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;

    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyControl());
    }

    IEnumerator enemyControl()
    {
        for (;;)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnEnemies();
        }
    }

    public void spawnEnemies()
    {
        Vector3 coordinate = new Vector3(Random.Range(-67f, 25f), Random.Range(4f, 99f), 0);
        Instantiate(Enemy, coordinate, Quaternion.identity).transform.parent = this.gameObject.transform;
    }
}
