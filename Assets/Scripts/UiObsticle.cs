using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiObsticle : MonoBehaviour
{
    public float timerToEndGame = 3f;
    public Color doomClr = Color.red;
    Color originalClr;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        originalClr = gameObject.GetComponent<Image>().color;
        StartCoroutine(timeToEndGame());
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timeToEndGame()
    {
        float timer = 0;
        while(timer <= timerToEndGame)
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(originalClr, doomClr, timer / timerToEndGame);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gameObject.GetComponent<Image>().color = Color.Lerp(originalClr, doomClr, 1);
        gameManager.restartLvl();
        yield return null;
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
