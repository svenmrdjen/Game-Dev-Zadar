using UnityEngine;

// zadatak ScoreManagera je upravljati bodovima
public class ScoreManager : MonoBehaviour
{
    // singleton
    public static ScoreManager Instance;

    private int score;

    public int Score
    {
        get { return score; }
    }

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

    public void IncreaseScore() 
    {
        // povećava bodove za 1
        score++;

        // zove UIManager da update-a stanje bodova na ekranu
        // kao parametar mu šalje trenutni score
        UIManager.Instance.WriteScore(score);
    }
}
