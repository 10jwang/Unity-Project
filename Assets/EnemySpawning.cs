using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] allEnemies;
    public int[] costs;
    private bool selected = false;
    private int enemyIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == false)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            enemyIndex = Random.Range(0, 4);
            Debug.Log(enemyIndex);
            selected = true;
        }
        else
        {
            if (costs[enemyIndex] <= MoneyHandlerScript.player2Money)
            {
                Instantiate(allEnemies[enemyIndex], this.transform.position, Quaternion.identity);
                MoneyHandlerScript.player2Money -= costs[enemyIndex];
                selected = false;
            }
        }
    }
}
