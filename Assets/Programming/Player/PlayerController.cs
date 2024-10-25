using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit des Spielers
    public float mouseSensitivity = 100f; // Empfindlichkeit der Mausbewegung
    public Transform playerCamera; // Die Kamera, die am Spieler hängt
    public Rigidbody rb; // Der Rigidbody des Spielers

    private float xRotation = 0f; // Rotation der Kamera um die X-Achse (für vertikale Bewegung)
    public float maxLookUpAngle = 80f; // Maximale vertikale Rotation (nach oben)
    public float maxLookDownAngle = -80f; // Maximale vertikale Rotation (nach unten)

    void Start()
    {
        // Versteckt den Mauszeiger und sperrt ihn in die Mitte des Bildschirms
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mausbewegung für Kamera steuern
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Begrenzte vertikale Bewegung (Kamera hoch/runter)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, maxLookDownAngle, maxLookUpAngle);

        // Rotiert die Kamera um die X-Achse (hoch/runter)
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotiert den Spieler um die Y-Achse (links/rechts)
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        // Spielerbewegung mit W, A, S und D basierend auf Physik
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveY;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
