using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greed : MonoBehaviour {

    private Rigidbody r;
    private Vector3 target = new Vector3(-1, -1);
    public Material evil;
    void getNearestTile()
    {
        float dist = float.MaxValue;
        GameObject[] gs = GameObject.FindGameObjectsWithTag("Trampoline");
        target = gs[Random.Range(0, gs.Length - 1)].transform.position;
        Debug.Log("Now targeting (" + target.x + ", " + target.z + ")");
    }

    void Start () {
        r = GetComponent<Rigidbody>();
    }

	void Update () {
        if (target.x < 0) return;
        Vector3 dist = target - transform.position;
        dist.y = 0;
        dist.x = dist.x / Mathf.Abs(dist.x);
        dist.z = dist.z / Mathf.Abs(dist.z);
        transform.Translate(dist * 0.04f);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            r.velocity = new Vector3(0, 10.0f, 0);
            collision.gameObject.name = "Evil";
            collision.gameObject.GetComponent<MeshRenderer>().material = evil;
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().material = evil;
            if ((target.x - transform.position.x + target.z - transform.position.z) < 2 || target.x < 0) getNearestTile();
        }
        else if (collision.gameObject.tag == "Respawn") Destroy(gameObject);
    }
}
