using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool Cantripleshot = false;


    public bool IsSpeedBoostActive = false;

    // Start is called before the first frame update

    // variable to know if you collected the speed boost
    [SerializeField]
    private GameObject _tripleShotPrefab;
    
    

    [SerializeField]
    private GameObject _LaserPrefabs;

    [SerializeField]
    private float _firerate = 0.25f;

    private float _nextfire = 0.0f;

    [SerializeField]
    private float speed = 4.5f;

    private void start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();

        // if space key pressed 
        // spawn laser at player position 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            shoot();
        }


    }
    private void shoot()
    {
        if (Time.time > _nextfire)

            if (Cantripleshot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity); 
            }
            else
            {
                Instantiate(_LaserPrefabs, transform.position + new Vector3(0, 0.92f, 0), Quaternion.identity);
            }
                _nextfire = Time.time + _firerate;

    }
    private void Movement()
    {
        
        {

            float horizontalInput = Input.GetAxis("Horizontal");

            float verticalInput = Input.GetAxis("Vertical");
            
            if (IsSpeedBoostActive == true)
            {
                transform.Translate(Vector3.right * speed* 2.0f * horizontalInput * Time.deltaTime);

                transform.Translate(Vector3.up * speed * 2.0f * verticalInput * Time.deltaTime);
            }
            else 
            {
               
                transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

                transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

            }


            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);


            // if player on the y is greater then 0 
            // set player position the y to 0

            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
            }
            else if (transform.position.y < -4.2f)
            {
                transform.position = new Vector3(transform.position.x, -4.2f, 0);
            }

            if (transform.position.x < -12.5)
            {
                transform.position = new Vector3(12.5f, transform.position.y, 0);
            }

            else if (transform.position.x > 12.5)
            {
                transform.position = new Vector3(-12.5f, transform.position.y, 0);
            }




        }
    }

         public void TirpleShotPowerupOn()
         {
          Cantripleshot = true;
          StartCoroutine(TripleShotPowerDownRoutine());

          
         }

    public void SpeedPowerupOn()
    {       
        IsSpeedBoostActive= true;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        IsSpeedBoostActive = false;

        
    }
    // method to enable to powerups 

    // corountine method (ienumerator) to power down speed boost 

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Cantripleshot = false;

            
    }
}



  
