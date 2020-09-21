using System.Collections;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public float damage = 100f;
    public float range = 1000f;

    public GameObject bulletPrefab;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {

        if  (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(fpsCam.transform.position, hit.point, Color.cyan, 1000f);
        }
    }
}
