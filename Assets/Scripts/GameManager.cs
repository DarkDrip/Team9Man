using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public int roundCounter = 0;
    
   

    public static GameManager Instance { get; private set; }

    [SerializeField] private Ghost[] ghosts;
    [SerializeField] private PacMan pacman;
    [SerializeField] private Transform pellets;
    
    
    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private int ghostMultiplier = 1;
<<<<<<< Updated upstream
    
=======
    public AudioSource audioSource;
    public AudioSource intro;
    public AudioSource eat;
    public AudioSource death;
    public AudioSource powerPellet;
    public AudioSource ghostEat;
    public AudioSource idleWobble;
>>>>>>> Stashed changes
    /*
    public GameManager scoreTextInit(TextMeshProUGUI scoreText)
    {
        this.scoreText = scoreText;
    }
    public GameManager livesTextInit(TextMeshProUGUI scoreText)
    {
        this.livesText = livesText;
    }
    */
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
<<<<<<< Updated upstream
        pacman.ResetState();
=======
        
>>>>>>> Stashed changes
        NewGame();
        scoreText.text = "Score: ";
        livesText.text = "Lives: 3";
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
            
<<<<<<< Updated upstream
=======
        }
        //idleWobble.Play();
        if (powerPellet.isPlaying || intro.isPlaying)
        {
            idleWobble.Pause();
        }

        if (!powerPellet.isPlaying && !intro.isPlaying)
        {
            idleWobble.Play();
>>>>>>> Stashed changes
        }
    }

    private void NewGame()
    {
        SetScore(0);
        scoreText.text = "Score: " + score;
        SetLives(3);
        
        NewRound();
    }

    private void NewRound()
    {
        
        
        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }
<<<<<<< Updated upstream
        roundCounter++;
=======
        
>>>>>>> Stashed changes
        if(roundCounter >= 2)
        {
            SceneManager.LoadScene("YouWin");
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
        livesText.text = "Lives: " + lives;
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = "Score: " + score;
    }

    public void PacmanEaten()
    {
        
        pacman.DeathSequence();
<<<<<<< Updated upstream

=======
        if (!death.isPlaying)
        {
            death.Play();
        }
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        if (!ghostEat.isPlaying)
        {
            ghostEat.Play();
        }
>>>>>>> Stashed changes
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);
        
        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {
<<<<<<< Updated upstream
=======
        if (!eat.isPlaying)
        {
            eat.Play();
        }

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        powerPellet.Play();

>>>>>>> Stashed changes
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
