using UnityEngine;

public class SFXManager : MonoBehaviour {
    public static SFXManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameStartSFX;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deadSFX;

    private bool wasPlayerEnabled = true;

    void Awake() {
        instance = this;
    }

    void Start() {
        if (gameStartSFX != null) {
            audioSource.PlayOneShot(gameStartSFX);
        }
    }

    void Update() {
        if (PlayerMovement.instance != null) {
            
            if (!PlayerMovement.instance.enabled && wasPlayerEnabled) {
                if (deadSFX != null) {
                    audioSource.PlayOneShot(deadSFX);
                }
                wasPlayerEnabled = false;
            }

            if (PlayerMovement.instance.enabled) {
                if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && PlayerMovement.instance.IsGrounded()) {
                    audioSource.PlayOneShot(jumpSFX);
                }
            }
        }
    }
}