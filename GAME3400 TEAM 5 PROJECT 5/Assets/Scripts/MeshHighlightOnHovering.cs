using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshHighlightOnHovering : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;
    [SerializeField]
    private float lightCoeff = 0.5f;
    private bool mouseClicked = false;

    private void Start()
    {
        if (gameObject.GetComponent<MoveableLight>().lightOn)
        {
            foreach (Renderer renderer in this.renderers)
            {
                renderer.material.color /= lightCoeff;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (gameObject.GetComponent<MoveableLight>().lightOn && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStuff>().hasLight)
            changeLightColor(lightCoeff);
        else if (!gameObject.GetComponent<MoveableLight>().lightOn && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStuff>().hasLight)
            changeLightColor(1 / lightCoeff);
    }

    private void OnMouseDown()
    {
        mouseClicked = true;
    }

    private void OnMouseExit()
    {
        if (!mouseClicked)
        {
            if (gameObject.GetComponent<MoveableLight>().lightOn && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStuff>().hasLight)
                changeLightColor(1 / lightCoeff);
            else if (!gameObject.GetComponent<MoveableLight>().lightOn && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStuff>().hasLight)
                changeLightColor(lightCoeff);
        }

        mouseClicked = false;
    }

    private void changeLightColor(float coeff)
    {
        foreach (Renderer renderer in this.renderers)
        {
            renderer.material.color *= coeff;
        }
    }
}