using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Gun
{
    // Start is called before the first frame update
    private bool arcadeMachineRelease = true;
    protected override bool getShootInput()
    {
        if (usingArcadeMachine)
        {
            if (arcadeMachineRelease && playerShoot.ReadValue<float>() > 0)
            {
                arcadeMachineRelease = false;
                return true;
            }
            else
            if (playerShoot.ReadValue<float>() < 0.1f)
            {
                arcadeMachineRelease = true;
            }
            return false;
            
        }
        else
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}
