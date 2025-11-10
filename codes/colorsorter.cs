using UnityEngine;

public class ColorPusher : MonoBehaviour
{
    [Header("Push Settings")]
    public float sidePushForce = 5f;

    [Header("Push Directions")]
    public Vector3 redPushDirection = new Vector3(-1f, -0.3f, 0f);   // red → left belt
    public Vector3 bluePushDirection = new Vector3(1f, -0.3f, 0f);   // blue → right belt

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            Renderer rend = other.GetComponent<Renderer>();
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (!rb || !rend) return;

            Color cubeColor = rend.material.color;
            Vector3 direction;

            // Decide push direction based on cube color
            if (cubeColor == Color.red)
                direction = redPushDirection.normalized;      // red → left
            else if (cubeColor == Color.blue)
                direction = bluePushDirection.normalized;     // blue → right
            else
                return; // ignore other colors

            // Apply one short impulse to make cube fall toward its respective conveyor
            rb.AddForce(direction * sidePushForce, ForceMode.Impulse);
        }
    }
}
