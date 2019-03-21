using UnityEngine;

[RequireComponent(typeof(playermotor))]
public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitvity = 3f;

    private playermotor motor;

    void Start ()
    {
        motor = GetComponent<playermotor>();
    }

    void Update()
    {
        //calculate movement velocity as a 3D vector
        float _zmov = Input.GetAxisRaw("Horizontal");
        float _xmov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _zmov; 
        Vector3 _movVertical = transform.forward * _xmov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        // apply movement
        motor.move(_velocity);

        float _yrot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yrot, 0f) * lookSensitvity;

        //Apply rotation 
        motor.Rotate(_rotation);

        // caculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitvity;

        //Apply camera rotation 
        motor.RotateCamera(_cameraRotation);
    }
}
