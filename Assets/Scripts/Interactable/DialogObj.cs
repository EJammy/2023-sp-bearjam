using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue/DialogueObj")]
public class DialogObj : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    public AudioClip voice = null;
    public string[] Dialogue => dialogue;
}
