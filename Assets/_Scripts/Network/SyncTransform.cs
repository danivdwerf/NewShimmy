using UnityEngine;

public class SyncTransform : Photon.MonoBehaviour 
{
    private Animator anim;

    private Vector3 position;
    private Quaternion rotation;
    private float velocity;
    private bool attack;

    private void Awake()
    {
        this.anim = this.GetComponent<Animator>();
        this.position = Vector3.zero;
        this.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (photonView.isMine)
            return;

        transform.position = Vector3.Lerp(transform.position, this.position, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, this.rotation, 0.1f);
        this.anim.SetFloat("velocity", Mathf.Lerp(anim.GetFloat("velocity"), this.velocity, 0.1f));
        this.anim.SetBool("attack", this.attack);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(anim.GetFloat("velocity"));
            stream.SendNext(anim.GetBool("attack"));
            return;
        }

        this.position = (Vector3)stream.ReceiveNext();
        this.rotation = (Quaternion)stream.ReceiveNext();
        this.velocity = (float)stream.ReceiveNext();
        this.attack = (bool)stream.ReceiveNext();
    }
}
