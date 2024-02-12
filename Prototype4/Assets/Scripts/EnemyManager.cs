using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyControl());
    }

    IEnumerator enemyControl()
    {
        for (;;)
        {
            yield return new WaitForSeconds(1f);
            spawnEnemies();
        }
    }

    public void spawnEnemies()
    {
        Vector3 coordinate = new Vector3(Random.Range(-67f, 24f), Random.Range(3f, 99f), 0);
        Instantiate(Enemy, coordinate, Quaternion.identity).transform.parent = this.gameObject.transform;
    }
}
