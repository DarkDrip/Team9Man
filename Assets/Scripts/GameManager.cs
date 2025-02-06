using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI livesText = livesText;
    public int roundCounter = 1;




    public static GameManager Instance { get; private set; }

    [SerializeField] private Ghost[] ghosts;
    [SerializeField] private PacMan pacman;
    [SerializeField] private Transform pellets;

    public AudioSource audioSource;
    public AudioSource intro;
    public AudioSource eat;
    public AudioSource death;
    public AudioSource powerPellet;
    public AudioSource ghostEat;
    public AudioSource idleWobble;




    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private int ghostMultiplier = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }

        if (!idleWobble.isPlaying)
        {
            idleWobble.Play();
        }

        if (powerPellet.isPlaying || intro.isPlaying)
        {
            idleWobble.Pause();
        }

        if (!powerPellet.isPlaying && !intro.isPlaying)
        {
            idleWobble.Play();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        

        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
      
        
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = "Score: " + score;
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();

        if (!death.isPlaying)
        {
            death.Play();
        }
        

        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        if (!ghostEat.isPlaying)
        {
            ghostEat.Play();
        }

        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);
        
        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {
        if (!eat.isPlaying)
        {
            eat.Play();
        }


        pellet.gameObject.SetActive(false);

        SetScore(score + pellet.points);
        scoreText.text = "Score: " + score;

        

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
            roundCounter++;
            Invoke(nameof(NewRound), 3f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {

        powerPellet.Play();

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }
}
