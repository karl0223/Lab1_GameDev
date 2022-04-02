using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float xMovement;
    [SerializeField] float yMovement;
    [SerializeField] float zMovement;
    [SerializeField] float SpeedBoost;
    [SerializeField] float SecChangeDir;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AlterDir());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(xMovement, yMovement, zMovement) * Time.deltaTime * SpeedBoost);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject pl = collision.gameObject;
            pl.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;

            player.transform.parent = null;
        }

    }

    IEnumerator AlterDir()
    {
        yield return new WaitForSeconds(SecChangeDir);

        xMovement = InverseNum(xMovement);
        yMovement = InverseNum(yMovement);
        zMovement = InverseNum(zMovement);

        StartCoroutine(AlterDir());

    }

    private float InverseNum (float num)
    {
        if (num > 0) return -num;
        else return Mathf.Abs(num);
    }
}
