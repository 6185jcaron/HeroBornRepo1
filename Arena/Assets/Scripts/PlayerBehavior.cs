using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //1
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;
    public LayerMask groundlayer;


    //2
    private float vInput;
    private float hInput;
    //1
    private Rigidbody _rb;

    private CapsuleCollider _col;

    void Start()
    {
        //3
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        //3
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        //4
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */

    }
    //1
    void FixedUpdate()
    {
        if(IsGrounded() && hInput.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity,
                ForceMode.Impulse);
        
        
          
            }

        }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.Blunds.center.x,
            _col.bounds, min.y,
            _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            capsulebotttom, distanceToGround, groundlayer,
            QueryTriggerInteractions.Ignore);
        return grounded;
        //2
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //3
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        //2
        Vector3 rotation = Vector3.up * hInput;
        //3
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        //4
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        //5
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
