using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSlave : MonoBehaviour {

    public GameObject Tile;
    public float gap = 0.3f;
    public int mapWidth = 10;
    public int mapHeight = 10;
    public float tileMaxSize = 5.0f;
    public float tileMinSize = 3.0f;
	void Start () {
        float startX = tileMaxSize / 2;
        float startY = tileMaxSize / 2;
        float finalX = (mapWidth * tileMaxSize) + ((mapWidth - 1) * gap);
        float finalY = (mapHeight * tileMaxSize) + ((mapHeight - 1) * gap);
        for (float x = startX; x < finalX; x += gap + tileMaxSize)
        {
            for (float y = startY; y < finalY; y += gap + tileMaxSize)
            {
                GameObject temp = GameObject.Instantiate(Tile, new Vector3(x, 0, y), Quaternion.identity, transform);
                temp.GetComponent<ParticleSystem>().Stop();
                float scale = Random.Range(tileMinSize, tileMaxSize);
                temp.transform.localScale = new Vector3(scale, scale, scale);
                temp.name = "Neutral";
            }
        }
	}
	
	void Update () {
		
	}
}
