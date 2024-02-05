using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public GameObject character;
    public Transform spawnPoint;
    public int spawnCost = 0;

    public Color wantedColor;
    public Color otherColor;
    public Button button;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCost > MoneyHandlerScript.player1Money)
        {
            ColorBlock cb = button.colors;
            cb.pressedColor = wantedColor;
            button.colors = cb;
        }
        else
        {
            ColorBlock cb = button.colors;
            cb.pressedColor = otherColor;
            button.colors = cb;
        }
    }
    public void onClick()
    {
        int playerMoney = MoneyHandlerScript.player1Money;
        if (spawnCost <= playerMoney)
        {
            MoneyHandlerScript.player1Money -= spawnCost;
            Instantiate(character, spawnPoint.position, Quaternion.identity);
        }

    }
}
