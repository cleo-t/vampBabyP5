using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbLadder : MonoBehaviour
{
    GameObject player;
    float initialSlope;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialSlope = player.GetComponent<CharacterController>().slopeLimit;
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            player.GetComponent<CharacterController>().slopeLimit = 80f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            player.GetComponent<CharacterController>().slopeLimit = initialSlope;
        }
    }
}
