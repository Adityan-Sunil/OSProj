using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCont : MonoBehaviour
{
    public bool select;
    public GameObject[] inp ;
    public bool[] inpCheck;
    public GameObject outp;
    public GameObject wire;
    private WireCont drawWire;

    public GameObject[] inpGate;
    public GameObject opGate;

    //public string name;
    public string gate;

    // Start is called before the first frame update
    void Start()
    {
        drawWire = wire.GetComponent<WireCont>();
        inpCheck = new bool[2];
        inpGate = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector3.back);
            if (hit)
            {
                if(hit.collider.gameObject == gameObject)
                {
                    select = true;
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            if(gameObject.name != "Output")
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector3.back);
                if (hit)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        deleteGate();
                    }
                }
            }   
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector3.back);
            if (hit)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(outp.transform.position);
                    drawWire.setStart(outp);
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector3.back);
            if (hit)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    for (int i = 0; i < inp.Length; i++)
                    {
                        if (!inpCheck[i])
                        {
                            drawWire.setEnd(inp[i]);
                            inpCheck[i] = true;
                            break;
                        }
                    }
                                     
                }
            }
        }

        if (select)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = newPos;
        }

        if(Input.GetMouseButtonUp(0) && select)
        {
            select = false;
        }
        

    }
    void deleteGate()
    {
        bool flag = false;
        for (int i = 0; i < inpGate.Length; i++)
        {
            if (inpCheck[i])
            {
                Debug.Log("deleting");
                int childCount = inpGate[i].transform.childCount;
                for (int j = 0; j < childCount; j++)
                {
                    if(inpGate[i].transform.GetChild(j).gameObject.GetComponent<WireData>().end.transform.parent == gameObject.transform)
                    {
                        Debug.Log(inpGate[i].transform.GetChild(j).gameObject.name);
                        Destroy(inpGate[i].transform.GetChild(j).gameObject);
                        GateCont prev = inpGate[i].transform.parent.gameObject.GetComponent<GateCont>();
                        prev.opGate = null;
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
                break;
        }
        Destroy(gameObject);
    }

    public string GetCode() {
        Debug.Log("getting code for " + gate + " gate");
        if (inp.Length == 1) {
            string ing = inpGate[0].transform.parent.gameObject.GetComponent<GateCont>().name;
            if (opGate.transform.parent.name == "Output")
                return gate + "(in=" + ing + ", out=out);";
            return gate + "(in=" + ing + ", out=" + name + ");";
        } else {
            Debug.Log(inpGate[0].transform.parent.gameObject);
            string a = inpGate[0].transform.parent.gameObject.GetComponent<GateCont>().name;
            string b = inpGate[1].transform.parent.gameObject.GetComponent<GateCont>().name;
            if (opGate.transform.parent.name == "Output")
                return gate + "(a=" + a + ", b=" + b + ", out=out);";
            return gate + "(a=" + a + ", b=" + b + ", out=" + name + ");";
        }
    }
    public void ResetPress()
    {
        Destroy(gameObject);
    }
}
