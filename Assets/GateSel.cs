using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSel : MonoBehaviour
{
    GameObject Gate;
    public GameObject GatePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnActive()
    {
        Vector2 SpawnLoc = new Vector2 (0f,0f); 
        Gate = Instantiate(GatePrefab,SpawnLoc,Quaternion.identity);
    }
}
