using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Variables
    public Canvas TextBox;
    public float timeToShow = 1;
    public float timeToClose = 0.5f;
    bool midAnimation;
    Coroutine currentRoutine;

    [SerializeField] private DialogUI dialogUI;

    public DialogUI DialogUI => dialogUI;

    public IInteractable interactable { get; set; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TextBox.GetComponent<CanvasGroup>().alpha = 0;
        midAnimation = false;
    }

    private void Update()
    {
        if (Statics.hasControl && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interact");
            if (interactable != null && !dialogUI.isOpen)
            {
                Debug.Log("Success");
                interactable.Interact(this);
            }
        }
    }

    public void displayInteractKey()
    {
        if (midAnimation)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(ShowTextBox());
    }

    public void closeInteractKey()
    {
        if (midAnimation)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(CloseTextBox());
    }

    IEnumerator ShowTextBox()
    {
        // Lerp
        midAnimation = true;
        float timeElapsed = 0;
        float initAlpha = TextBox.GetComponent<CanvasGroup>().alpha;

        while (timeElapsed <= timeToShow)
        {
            TextBox.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(initAlpha, 1, timeElapsed / timeToShow);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        TextBox.GetComponent<CanvasGroup>().alpha = 1;
        currentRoutine = null;
        midAnimation = false;
        yield return null;
    }

    IEnumerator CloseTextBox()
    {
        // Lerp
        midAnimation = true;
        float timeElapsed = 0;
        float initAlpha = TextBox.GetComponent<CanvasGroup>().alpha;

        while (timeElapsed <= timeToShow)
        {
            TextBox.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(initAlpha, 0, timeElapsed / timeToClose);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        TextBox.GetComponent<CanvasGroup>().alpha = 0;
        currentRoutine = null;
        midAnimation = false;
        yield return null;
    }
}
