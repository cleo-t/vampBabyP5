using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbStep : MonoBehaviour
{
    [SerializeField]
    private List<MoveableLight> lightsToBeOff;

    public bool SafeToAdvance()
    {
        foreach (MoveableLight ml in this.lightsToBeOff)
        {
            if (ml.lightOn)
            {
                return false;
            }
        }
        return true;
    }
}
