using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    private void Start()
    {
        Prog.Inst.FaindText();

    }
    
    void Update()
    {
        Prog.Inst.UpdateText();
    }
}
