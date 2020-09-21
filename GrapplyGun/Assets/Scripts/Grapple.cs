using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 300f;

    public GameObject grappler;

    public Rigidbody grapplerRb;

    public SpringJoint springJoint;

    private void Start()
    {
        grapplerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        springJoint.anchor = grappler.transform.position;

        if (Input.GetButtonDown("Fire1"))
            Grappler();
    }

    void FixedUpdate()
    {
        
    }

    void Grappler()
    {
        RaycastHit hit;
        if (Physics.Raycast(grappler.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(grappler.transform.position, hit.point, Color.cyan, 1000f);

            springJoint.maxDistance = Vector3.Distance(grappler.transform.position, hit.point);
            springJoint.minDistance = 2;

            springJoint.connectedAnchor = hit.point;
        }
        else
        {

        }
    }
}
