using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCont : MonoBehaviour
{
    private GameObject start;
    private GameObject end;
    public GameObject wirePre;
    private GameObject wire;
    private WireData wireScript;
    public void setStart(GameObject outp)
    {
        start = outp;
        Debug.Log(start.transform.position);
    }
    public void setEnd (GameObject inpt)
    {
        end = inpt;
        Debug.Log(end.transform.position);
        drawLine();
    }
    
    void drawLine()
    {
        wire = Instantiate(wirePre,start.transform);
        wireScript = wire.GetComponent<WireData>();
        wireScript.wireConnect(start, end);

    }
}
