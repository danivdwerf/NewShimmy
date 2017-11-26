using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Photon.MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float runSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    private float runScaler;

    private Animator anim;
    private int _velocityAnim;

    private Rigidbody rigid;
    private Vector3 movement;

    private Camera mainCam;

    private void Start()
    {
        runScaler = 0;
        movement = Vector3.zero;
       
        this.anim = this.GetComponent<Animator>();
        this._velocityAnim = Animator.StringToHash("velocity");
        this.mainCam = this.GetComponent<PlayerCam>().PlayerCamera;
        Cursor.lockState = CursorLockMode.Locked;

        rigid = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        if (!photonView.isMine)
            return;
        
        var x = Input.GetAxisRaw (Controller.LeftStickX);
        anim.SetFloat("direction", x);
        var z = Input.GetAxisRaw (Controller.LeftStickY);
        if ((z!=0 || x!=0) && Input.GetButton(Controller.Run))
            runScaler = runSpeed;
        else
            runScaler = 1;

        movement = new Vector3 (x, 0, -z);
    }

    private void FixedUpdate()
    {
        if (!photonView.isMine)
            return;
        
        if (this.mainCam == null)
            return;
        
        var movementDirection = mainCam.transform.TransformDirection(movement);
        var leftCross = Vector3.Cross(movementDirection, Vector3.up);
        var forwardCross = Vector3.Cross(Vector3.up, leftCross);
        Vector3 velocity = forwardCross * speed * runScaler * Time.fixedDeltaTime;
        velocity.y = 0.0f;
           
        if(velocity != Vector3.zero)
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(velocity), this.rotationSpeed);

        rigid.MovePosition(rigid.position + velocity);
        anim.SetFloat(_velocityAnim, velocity.sqrMagnitude);
    }
}