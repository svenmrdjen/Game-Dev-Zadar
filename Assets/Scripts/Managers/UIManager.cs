using UnityEngine;

using UnityEngine.UI;

// za rad s TextMeshPro elementima, potrebno je dodati ovaj namespace:
using TMPro;

// UIManager kontrolira User Interface
public class UIManager : MonoBehaviour
{
    // singleton
    public static UIManager Instance;

    public TextMeshProUGUI scoreText; 
    public RawImage crosshairs;

    private void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    private void Start()
    {
        // na početku umjesto placeholder teksta
        // zapisujemo početnu vrijednost score-a
        scoreText.SetText("Score: " + 0);
    }

    // UIManager prima vrijednost score od ScoreManager-a
    // zatim tu vrijednost ispisuje na ekranu
    public void WriteScore(int score)
    {
        scoreText.SetText("Score: " + score);
    }

    public void ChangeCrosshairs(Color color)
    {
        crosshairs.color = color;
    }
}
