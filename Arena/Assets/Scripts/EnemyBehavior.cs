using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
        //1
        void onTriggerEnter(Collider other)
        {
            //2
            if (other.name == "Player")
            {
                Debug.Log("Player detected - Attack!");
            }
        }
        //3
        void OnTriggerExit(Collider other)
        {
            //4
            if (other.name == "Player")
            {
                Debug.Log("Player out of range, resume patrol");
            }
        }
    
}
