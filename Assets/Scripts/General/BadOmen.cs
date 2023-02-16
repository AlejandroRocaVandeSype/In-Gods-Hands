using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadOmen : MonoBehaviour
{
    private float _LifeTime = 30.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _LifeTime -=Time.deltaTime;
        if(_LifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        Destroy(other.gameObject);

        if(other.gameObject.layer == 11)
        Destroy(other.gameObject);

    }
}
