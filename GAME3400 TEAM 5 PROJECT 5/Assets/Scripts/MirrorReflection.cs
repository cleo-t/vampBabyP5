using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MirrorReflection : MonoBehaviour
{
    [SerializeField]
    private Vector3 normal = Vector3.forward;

    new private Camera camera;

    void Start()
    {
        this.camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 fromCamera = this.MainCameraLookVector();
        Vector3 reflection = Vector3.Reflect(fromCamera, this.normal);
        this.transform.rotation = Quaternion.LookRotation(reflection, Vector3.up);
    }

    private Vector3 MainCameraLookVector()
    {
        return (this.transform.position - Camera.main.transform.position).normalized;
    }
}
