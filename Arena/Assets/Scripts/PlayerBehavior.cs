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
    public GameObject bullet;
    public float bulletSpeed = 100f;


    //2
    private float vInput;
    private float hInput;
    private GameBehavior _gameManager;
    //1
    private Rigidbody _rb;

    private CapsuleCollider _col;

    void Start()
    {
        //3
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

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
        //2
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //3
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,
                this.transform.position + new Vector3(1, 0, 0),
                this.transform.rotation) as GameObject;
            Rigidbody bulletRB =
                newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward *
                bulletSpeed;
        }
    }
    //1
    void FixedUpdate()
    {
        
            

                //2
        Vector3 rotation = Vector3.up * hInput;
                //3
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
                //4
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
                //5
        _rb.MoveRotation(_rb.rotation * angleRot);
       
            

        

    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
            _col.bounds.min.y,
            _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            capsuleBottom, distanceToGround, groundlayer,
            QueryTriggerInteraction.Ignore);
        return grounded;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }

}
