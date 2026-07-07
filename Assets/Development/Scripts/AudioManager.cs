using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource mainMenuMusic;
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] private AudioSource obstacleSound;
    [SerializeField] private AudioSource cheeseSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource rightFootSfx;
    [SerializeField] private AudioSource leftFootSfx;

    public static AudioManager Instance; 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        mainMenuMusic.Play();
    }

    public void PlayGameMusic()
    {
        mainMenuMusic.Stop();
        gameMusic.Play();
    }

    public void PlayObstacle()
    {
        obstacleSound.Play();
    }

    public void PlayCheese()
    {
        cheeseSound.Play();
    }

    public void PlayJump()
    {
        jumpSound.Play();
    }

    public void PlayStepRightFootSound()
    {
        rightFootSfx.Play();
    }
    public void PlayStepLeftFootSound()
    {
        leftFootSfx.Play();
    }
}
