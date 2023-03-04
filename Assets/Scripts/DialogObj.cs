using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObj")]
public class DialogObj : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
