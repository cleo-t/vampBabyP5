using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoorOnSwitch : MonoBehaviour
{
    [SerializeField]
    private float arcDegrees = 90;
    [SerializeField]
    private float moveDuration = 0.75f;
    [SerializeField]
    private AudioClip doorSlamClip;

    void Start()
    {
        DoorSwitchCollider.OnSwitchDoors += this.OnDoorSwitch;
    }

    private void OnDoorSwitch()
    {
        Debug.Log("ACKNOWLEDGED!");
        StartCoroutine(this.MoveDoor());
    }

    private IEnumerator MoveDoor()
    {
        float degreesMoved = 0;
        float degreesPerSecond = this.arcDegrees / this.moveDuration;
        while(Mathf.Abs(degreesMoved) < Mathf.Abs(this.arcDegrees))
        {
            float step = degreesPerSecond * Time.deltaTime;
            this.transform.localRotation *= Quaternion.AngleAxis(step, Vector3.up);
            degreesMoved += step;
            yield return null;
        }
        this.transform.localRotation *= Quaternion.AngleAxis(this.arcDegrees - degreesMoved, Vector3.up);
        AudioSource.PlayClipAtPoint(this.doorSlamClip, this.transform.position);
    }
}
