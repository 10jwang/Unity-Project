using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandlerScript : MonoBehaviour
{
    public static int player1Money = 0;
    public int player1Increment = 10;
    public static int player2Money = 0;
    public int player2Increment = 10;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            player1Money += player1Increment;
            player2Money += player2Increment;
            timer = 0;
        }
    }
}
