using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float runSpeed;

    private Animator anim;
    private int _velocityAnim;

    private float runScaler;
    private Rigidbody rigid;
    private Vector3 movement;
    private Vector3 prevMovement;
    private Camera camera;

    private void Start()
    {
        runScaler = 0;
        movement = Vector3.zero;
        prevMovement = Vector3.zero;
        this.camera = Camera.main;
        this.anim = this.GetComponent<Animator>();
        this._velocityAnim = Animator.StringToHash("velocity");

        rigid = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        var x = Input.GetAxisRaw (Controller.LeftStickX) * speed;
        var z = Input.GetAxisRaw (Controller.LeftStickY) * speed;
        if ((z!=0 || x!=0) && Input.GetButton(Controller.LeftThumb))
            runScaler = runSpeed;
        else
            runScaler = 1;

        movement = new Vector3 (x, 0, z);

        if (x != 0 && z != 0)
            prevMovement = movement;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = camera.transform.TransformDirection(movement) * runScaler * Time.fixedDeltaTime;
        velocity.y = 0.0f;
        rigid.MovePosition(rigid.position + velocity);
        anim.SetFloat(_velocityAnim, velocity.sqrMagnitude);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(prevMovement), 0.1f);
    }
}