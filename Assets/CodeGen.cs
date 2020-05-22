using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CodeGen : MonoBehaviour
{
    GameObject[] gates;
    GameObject[] inputs;
    GameObject output;

    public void StartGenerating() {
        gates = GameObject.FindGameObjectsWithTag("Gate");
        inputs = GameObject.FindGameObjectsWithTag("Input");
        output = GameObject.FindGameObjectWithTag("Output");
        Generate();
    }

    void Generate() {
        StreamWriter writer = new StreamWriter("code.hdl");
        writer.WriteLine("CHIP MyChip {");
        writer.Write("\tIN");
        for (int i = 0; i < inputs.Length; i++) {
            if(i != 0) {
                writer.Write(",");
            }
            inputs[i].GetComponent<GateCont>().name = "in" + i.ToString();
            writer.Write(" in" + i.ToString());
        }
        writer.Write(";\n\tOUT out;\n");
        writer.WriteLine("\n\tPARTS:");
        int opInd = 0;
        bool[] opAvailable = new bool[gates.Length];
        for (int i = 0; i < gates.Length; i++) {
            if (opAvailable[i]) {
                continue;
            }

            GateCont gate = gates[i].GetComponent<GateCont>();
            bool ipAvailable = true;
            foreach (var ip in gate.inpGate) {
                if (ip != null) {
                    GameObject ipGate = ip.transform.parent.gameObject;
                    if (ipGate.tag == "Gate" && !opAvailable[Array.IndexOf(gates, ipGate)]) {
                        ipAvailable = false;
                        break;
                    }
                }                
            }

            if (!ipAvailable) {
                continue;
            }

            opAvailable[i] = true;
            gate.name = "gate" + opInd.ToString();
            writer.WriteLine("\t" + gate.GetCode());
            opInd++;
            i = -1;
        }
        writer.WriteLine("}");
        writer.Flush();
    }
}
