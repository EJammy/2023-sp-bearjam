using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float writingSpeed = 40f;
    private AudioSource audio;
    [SerializeField] private AudioClip defaultVoice;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public bool IsRunning { get; private set; }

    private readonly List<Punctuation> punctuations = new List<Punctuation>
    {
        new Punctuation(new HashSet<char>() {'.', '!', '?',  }, 0.5f ),
        new Punctuation(new HashSet<char>() {',', ';', ':',  }, 0.3f ),
    };

    private Coroutine typingRoutine;

    public void Run(string textToType, TMP_Text textLabel, AudioClip voice)
    {
        if (voice == null)
        {
            voice = defaultVoice;
        }
        audio.clip = voice;

        typingRoutine = StartCoroutine(TypeText(textToType, textLabel));
    }

    public void Stop()
    {
        StopCoroutine(typingRoutine);
        IsRunning = false;
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        IsRunning = true;
        float timer = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            timer += Time.deltaTime * writingSpeed;

            charIndex = Mathf.FloorToInt(timer);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for(int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLabel.text = textToType.Substring(0, i + 1);

                if (!audio.isPlaying)
                    audio.Play();

                if (IsPunctuation(textToType[i], out float waitTime) && !isLast)
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        IsRunning = false;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach(Punctuation category in punctuations)
        {
            if (category.Punctuations.Contains(character))
            {
                waitTime = category.WaitTime;
                return true;
            }
        }

        waitTime = default;
        return false;
    }

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;

        public Punctuation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }
}
