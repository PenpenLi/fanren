using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class TestProcedure : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            GameEntry.UI.OpenUIForm(UIFormId.Battle);
        }
    }
}