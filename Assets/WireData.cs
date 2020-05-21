using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireData : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    LineRenderer line;
    public bool connected;
    GateCont stGate;
    GateCont edGate;
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        //connected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (connected)
        {
            line.SetPosition(0, start.transform.position);
            line.SetPosition(1, end.transform.position);

        }
    }

    public void wireConnect(GameObject p1, GameObject p2)
    {
        start = p1;
        end = p2;
        connected = true;
        stGate = p1.transform.parent.gameObject.GetComponent<GateCont>();
        edGate = p2.transform.parent.gameObject.GetComponent<GateCont>();
        for (int i = 0; i < edGate.inpGate.Length; i++)
        {
            if (!edGate.inpGate[i])
            {
                edGate.inpGate[i] = start;
                stGate.opGate = end;
                break;
            }
        }
    }
}
