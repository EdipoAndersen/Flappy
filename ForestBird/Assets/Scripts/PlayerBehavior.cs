using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float birdVerticalSpeed = 1f;
    [SerializeField] private float birdRotation = 1f;
    [SerializeField] private SoundManager soundManager;

    private Rigidbody2D birdRigidbody;

    void Start()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            addVelocity();
        }
        transform.rotation = Quaternion.Euler(0, 0, birdRigidbody.velocity.y * birdRotation);
    }

    public void addVelocity()
    {
        birdRigidbody.velocity = Vector2.up * birdVerticalSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        soundManager.HitObject();
        GameManager.instance.GameOver();
    }
}
