using TMPro;
using UnityEngine;

public class ListCell : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textGUI;

    public TextMeshProUGUI GetEditableElement() { 
        return _textGUI; 
    }
}
