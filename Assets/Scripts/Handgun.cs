using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Gun
{
    // Start is called before the first frame update
    protected override bool getShootInput()
    {
        return Input.GetMouseButtonDown(0);
    }
}
