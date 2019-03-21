using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //varible for your speed 
    private float _speed = 4.0f;
  

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);






            //when off the screen on the bottom
            // respawn back at the tom in a new X position within the bounds of the screen
            if (transform.position.y < -5.5)
            {
                transform.position = new Vector3(Random.Range(-11, 11), 4.5f, 0);
            }

                
        }



    }   
}


   