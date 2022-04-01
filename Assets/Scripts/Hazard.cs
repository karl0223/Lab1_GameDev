using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private Transform player;
     
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDed());
        }
    }
        
     
        IEnumerator PlayerDed()
        {
        player.GetComponent<MeshRenderer>().enabled = false;
        control playerControls = player.GetComponent<control>();
        playerControls.enabled = false;

        yield return new WaitForSeconds(2f);

        //respawn
        player.transform.position = new Vector3(52, -96 , -28); 
        player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        player.GetComponent<MeshRenderer>().enabled = true;


    }
    }

