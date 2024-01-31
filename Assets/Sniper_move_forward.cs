using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_move_forward : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(speed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);
    }
}
