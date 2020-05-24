using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] objs;
    public void OnPressButton()
    {
        objs = GameObject.FindGameObjectsWithTag ("Gate");
        if (objs.Length > 0)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                Destroy(objs[i]);
            }
        }
        objs = GameObject.FindGameObjectsWithTag("Input");
        if (objs.Length > 0)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                Destroy(objs[i]);
            }
        }


    }
}
