using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{


    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID; //0 = tirple shot 1 = speed boost, 2 = shields

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        Debug.Log("collided with: " + other.name);

        if (other.tag == "Player")
        {

            //access the player 
            Player player = other.GetComponent<Player>();
            
            if (player != null)
            {

                // turn the triple shot bool to ture
                if (powerupID == 0)
                {
                    player.TirpleShotPowerupOn();
                }

                else if (powerupID == 1)
                {
                    player.SpeedPowerupOn();
                }

                else if (powerupID == 2)
                {
                    // enable shilds boost
                }


               


            }
            // turn the triple shot bool to ture
            
            
             Destroy(this.gameObject);

         
        }



    }
}
