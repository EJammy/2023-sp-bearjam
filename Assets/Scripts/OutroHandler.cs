using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutroHandler : MonoBehaviour
{
    [SerializeField] private GameObject dialogUI;

    [SerializeField] private DialogObj outro1;
    [SerializeField] private DialogObj outro2;

    [SerializeField] private UnityEvent outro1UE;
    [SerializeField] private UnityEvent outro2UE;

    [SerializeField] private GameObject cutscene1;
    [SerializeField] private GameObject cutscene2;

    [SerializeField] private GameObject finalAudio;

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
            isPlaying = true;
            StartCoroutine(ShowObject(cutscene1, 5));
            gameObject.GetComponent<AudioSource>().Play();
            dialogUI.GetComponent<DialogUI>().ShowDialogue(outro1, outro1UE);
        }
    }

    IEnumerator ShowObject(GameObject objToShow, float timeToShow)
    {
        // Lerp
        float timeElapsed = 0;
        float initAlpha = objToShow.GetComponent<CanvasGroup>().alpha;

        while (timeElapsed <= timeToShow)
        {
            objToShow.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(initAlpha, 1, timeElapsed / timeToShow);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        objToShow.GetComponent<CanvasGroup>().alpha = 1;
        yield return null;
    }

    public void FuncOutro1()
    {
        cutscene1.SetActive(false);
        dialogUI.GetComponent<AudioSource>().volume = 0.5f;
        gameObject.GetComponent<AudioSource>().Stop();
        dialogUI.GetComponent<DialogUI>().ShowDialogue(outro2, outro2UE);
    }

    public void FuncOutro2()
    {
        StartCoroutine(ShowObject(cutscene2, 5));
        StartCoroutine(FinalCutscene());
        finalAudio.GetComponent<AudioSource>().Play();
    }

    IEnumerator FinalCutscene()
    {
        yield return new WaitForSeconds(7);
    }

}
