using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// za rad sa SceneManagerom, potrebno je dodati ovaj namespace:
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // singleton
    public static LevelManager Instance;

    [SerializeField] Animator transition;

    // Awake se izvršava prije Start metode
    private void Awake() 
    {
        // ako ne postoji instanca ove klasa u sceni, stvori ju
        // ako pak već postoji, uništi ovu instancu
        // tako da nemamo više instanci u sceni
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void GoToNextScene()
    {
        // SceneManager klasa na sebi ima LoadScene metodu
        // ova verzija LoadScene-a kao parametar uzima index sljedeće scene
        // također postoji verzija koja kao parametar uzima ime scene
        // P.S. ne zaboraviti dodati sve scene u build settings
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Application.Quit();
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
         
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
