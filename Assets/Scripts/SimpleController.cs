using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleController : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody rb;
    private Vector3 initialPosition;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !rb.useGravity)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !rb.useGravity)
        {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!rb.useGravity)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
            else
            {
                rb.useGravity = false;
                rb.isKinematic = true;
                transform.position = initialPosition;
            }
        }
    }
}