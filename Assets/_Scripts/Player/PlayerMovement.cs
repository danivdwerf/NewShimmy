using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Photon.MonoBehaviour
{
    [SerializeField]private float sneakSpeed = 2.0f;
    [SerializeField]private float walkSpeed = 4.0f;
    [SerializeField]private float runSpeed = 6.0f;
    [SerializeField]private float rotationSpeed = 1.0f;

    private float currentSpeedMultiplier;

    private Animator anim;
    private int _velocityAnim;

    private Rigidbody rigid;
    private Vector3 movement;

    private Camera mainCam;

    private void Start()
    {
        this.movement = Vector3.zero;
        this.currentSpeedMultiplier = 0.0f;
       
        this.anim = this.GetComponent<Animator>();
        this._velocityAnim = Animator.StringToHash("velocity");
        this.mainCam = this.GetComponent<PlayerCam>().PlayerCamera;
        Cursor.lockState = CursorLockMode.Locked;

        this.rigid = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        if (!photonView.isMine)
            return;

        var x = Input.GetAxisRaw(Controller.LeftStickX);
        var z = Input.GetAxisRaw(Controller.LeftStickY);
        movement = new Vector3(x, 0, -z);
        anim.SetFloat("direction", x);

        var sqrtMag = movement.sqrMagnitude;
        if (sqrtMag < 0.1f)
            this.currentSpeedMultiplier = 0.0f;
        if (sqrtMag > 0.1f)
            this.currentSpeedMultiplier = this.sneakSpeed;
        if (sqrtMag > 0.5f)
            this.currentSpeedMultiplier = this.walkSpeed;
        if (Input.GetButton(Controller.Run))
            this.currentSpeedMultiplier = this.runSpeed;
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
        Vector3 velocity = forwardCross.normalized * this.currentSpeedMultiplier * Time.fixedDeltaTime;
        velocity.y = 0.0f;
           
        if(velocity != Vector3.zero)
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(velocity), this.rotationSpeed);

        rigid.MovePosition(rigid.position + velocity);
        anim.SetFloat(_velocityAnim, velocity.sqrMagnitude);
    }
}