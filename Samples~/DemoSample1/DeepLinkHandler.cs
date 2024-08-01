using UnityEngine;
using TMPro;

public class DeepLinkHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TMP_InputField inputField;

    void Start() => ShusmoAPI.Link.Init("gamename");

    void OnEnable() => ShusmoAPI.Link.OnActivation += HandleDeepLinkActivation;

    void OnDisable() => ShusmoAPI.Link.OnActivation -= HandleDeepLinkActivation;

    private void HandleDeepLinkActivation(string message) 
    {
        // Check if the game was launched from a deep link
        if (!string.IsNullOrEmpty(message))
            messageText.text = message;
    }

    public void Open() => Application.OpenURL(ShusmoAPI.Link.GenerateMessage(inputField.text));
}
