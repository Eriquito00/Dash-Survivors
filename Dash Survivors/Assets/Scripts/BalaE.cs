using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limite") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaP"))
        {
            Destroy(this.gameObject);
        }
    }
}
