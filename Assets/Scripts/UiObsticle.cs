using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiObsticle : MonoBehaviour
{
    public static event System.Action uiObsticleDie;

    public float timerToEndGame = 3f;
    public Color doomClr = Color.red;
    Color originalClr;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        if(gameManager.difficulty > 1)
        {
            timerToEndGame = gameManager.difficultyStates[gameManager.difficulty - 2].uiObsticleLifetime;
        }
        originalClr = gameObject.GetComponent<Image>().color;
        StartCoroutine(timeToEndGame());
        StartCoroutine(dieUi());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dieUi()
    {
        yield return new WaitForSeconds(timerToEndGame);
        uiObsticleDie();
    }

    IEnumerator timeToEndGame()
    {
        float timer = 0;
        while(timer <= timerToEndGame)
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(originalClr, doomClr, timer / timerToEndGame);
            timer += Time.deltaTime;
            yield return null;
            //yield return new WaitForEndOfFrame();
        }
        gameObject.GetComponent<Image>().color = doomClr;
        if(uiObsticleDie != null)
        {
            //uiObsticleDie();
        }
        yield return null;
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
