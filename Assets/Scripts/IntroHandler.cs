using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroHandler : MonoBehaviour
{
    [SerializeField] private GameObject dialogUI;
    [SerializeField] private DialogObj introDialog1;
    [SerializeField] private DialogObj introDialog2;
    [SerializeField] private DialogObj introDialog3;
    [SerializeField] private DialogObj introDialog4;
    [SerializeField] private GameObject bookImage;
    [SerializeField] private GameObject candyImage;
    [SerializeField] private GameObject transition;

    [SerializeField] private UnityEvent intro2;
    [SerializeField] private UnityEvent intro3;
    [SerializeField] private UnityEvent intro4;
    [SerializeField] private UnityEvent playGame;

    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            StartCoroutine(ShowObject(bookImage));
            dialogUI.GetComponent<DialogUI>().ShowDialogue(introDialog1, intro2);
            isPlaying = true;
        }
    }

    IEnumerator ShowObject(GameObject objToShow)
    {
        // Lerp
        float timeElapsed = 0;
        float initAlpha = objToShow.GetComponent<CanvasGroup>().alpha;
        float timeToShow = 3;

        while (timeElapsed <= timeToShow)
        {
            objToShow.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(initAlpha, 1, timeElapsed / timeToShow);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        objToShow.GetComponent<CanvasGroup>().alpha = 1;
        yield return null;
    }

    public void Intro2()
    {
        bookImage.SetActive(false);
        dialogUI.GetComponent<DialogUI>().ShowDialogue(introDialog2, intro3);
    }

    public void Intro3()
    {
        StartCoroutine(ShowObject(candyImage));
        dialogUI.GetComponent<DialogUI>().ShowDialogue(introDialog3, intro4);
    }
    
    public void Intro4()
    {
        candyImage.SetActive(false);
        gameObject.GetComponent<AudioSource>().Play();
        dialogUI.GetComponent<DialogUI>().ShowDialogue(introDialog4, playGame);
    }

    public void PlayGame()
    {
        transition.GetComponent<TransitionManager>().PlayScene();
    }
}
