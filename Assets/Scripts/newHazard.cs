using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newHazard : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Out");
            PlayerOut();
        }
    }

    private void PlayerOut()
    {
        player.GetComponent<SkinnedMeshRenderer>().enabled = false;
        player.GetComponent<MeshRenderer>().enabled = false;
    }
}
