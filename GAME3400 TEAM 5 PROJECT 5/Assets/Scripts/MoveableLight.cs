using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableLight : MonoBehaviour
{
    public bool lightOn = true;

    public PlayerStuff player;
    public GameObject light;




    // Start is called before the first frame update
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStuff>();
            
        }
        light.SetActive(lightOn);
    }

    private void OnMouseDown()
    {
        if (lightOn && !player.hasLight)
        {
            lightOn = !lightOn;
            light.SetActive(lightOn);
            player.hasLight = true;
        }
        else if (!lightOn && player.hasLight)
        {
            lightOn = !lightOn;
            light.SetActive(lightOn);
            player.hasLight = false;
        }
    }
}
