using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private Rigidbody r;
    private Vector3 spawn;
    public Camera eyes;
    public Material good;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
        spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float rotationY = Input.GetAxis("Mouse X");
        float rotationX = Input.GetAxis("Mouse Y");
        eyes.transform.Rotate(rotationX * -12.0f, 0, 0);
        transform.Rotate(0, rotationY * 12.0f, 0);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(0, -1.2f, 0);
        else if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(0, 1.2f, 0);

        Vector3 delta = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) delta.z = 0.25f;
        else if (Input.GetKey(KeyCode.S)) delta.z = -0.25f;
        if (Input.GetKey(KeyCode.A)) delta.x = -0.25f;
        else if (Input.GetKey(KeyCode.D)) delta.x = 0.25f;
        transform.Translate(delta, Space.Self);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = good;
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().material = good;
            r.velocity = new Vector3(0, 10.0f, 0);
        }
        else if (collision.gameObject.tag == "Respawn") transform.position = spawn;
    }
}
