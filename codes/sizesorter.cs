using UnityEngine;

public class CubePusher : MonoBehaviour
{
    public float sidePushForce = 5f; // how strongly to push sideways
    public Vector3 smallPushDirection = new Vector3(-1f, -0.3f, 0f);   // left and slightly downward
    public Vector3 mediumPushDirection = new Vector3(0f, -0.3f, 1f);   // straight forward and slightly downward
    public Vector3 largePushDirection = new Vector3(1f, -0.3f, 0f);    // right and slightly downward

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (!rb) return;

            float size = other.transform.localScale.x;

            Vector3 direction;

            // Decide which way to push based on cube size
            if (Mathf.Approximately(size, 0.1f))
                direction = smallPushDirection.normalized;     // small → left belt
            else if (Mathf.Approximately(size, 0.25f))
                direction = mediumPushDirection.normalized;    // medium → center belt
            else
                direction = largePushDirection.normalized;     // large → right belt

            // Apply one short impulse to make cube fall toward its respective conveyor
            rb.AddForce(direction * sidePushForce, ForceMode.Impulse);
        }
    }
}
