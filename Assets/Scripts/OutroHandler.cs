using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroHandler : MonoBehaviour
{
    [SerializeField] private GameObject dialogUI;

    [SerializeField] private DialogObj Outro1;

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
            dialogUI.GetComponent<DialogUI>().ShowDialogue(Outro1, null);
        }
    }
}
