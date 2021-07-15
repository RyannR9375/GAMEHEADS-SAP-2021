using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{

    [SerializeField] private TMP_Text textLabel;

    private void Start()
    {
        GetComponent<TypeWriterEffect>().Run("This is a bit of text\nHello", textLabel);
    }
}