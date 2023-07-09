using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] 
    private GameObject Maulwurf;

    [SerializeField] private float Maulwurfinterval = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( spawnEnemy(Maulwurfinterval, Maulwurf));

    }

    // Update is called once per frame

    private IEnumerator spawnEnemy(float interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-15f, 15), Random.Range(-10f, 13f), 0),
            Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, Enemy));
    }
}
