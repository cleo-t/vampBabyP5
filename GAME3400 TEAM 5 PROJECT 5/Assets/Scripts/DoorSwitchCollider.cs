using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorSwitchCollider : MonoBehaviour
{
    public static event Action OnSwitchDoors;

    [SerializeField]
    private string bbTag = "Baby";

    private bool hit;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("INIT");
        this.hit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCHED");
        if (!this.hit && other.CompareTag(this.bbTag))
        {
            Debug.Log("HIT!");
            this.hit = true;
            StartCoroutine(this.SwitchDoorsWithDelay(2));
        }
    }

    private IEnumerator SwitchDoorsWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.BroadcastDoorSwitch();
    }

    private void BroadcastDoorSwitch()
    {
        if (OnSwitchDoors != null)
        {
            OnSwitchDoors.Invoke();
        }
    }
}
