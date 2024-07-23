# DeepLinks
This Unity Deep Links tool allows you to handle deep linking in your Unity game for both Android and iOS platforms. It includes scripts to handle deep links and a sample implementation to demonstrate its use.

- 🔗 **[Video Tutorial](https://youtu.be/i_TRpT_5C1E](https://youtu.be/HRiejA5-3tU?si=mzcqsoIUq-Z8zsiM))**

<br>

## Unity Code Setup
You need to Initialize the tool with your scheme value And Subscribe to the 'OnActivation' event.

```csharp
using UnityEngine;
using ShusmoSystems.DeepLink;

public class DeepLinkHandler : MonoBehaviour
{
    void Start() => Link.Init("scheme");

    void OnEnable() => Link.OnActivation += HandleDeepLinkActivation;

    void OnDisable() => Link.OnActivation -= HandleDeepLinkActivation;

    private void HandleDeepLinkActivation(string message) => Debug.Log(message);
}

```
<details>
<summary><b>Extra functionality</b></summary>
    
```csharp

    // The tool ID provided on Initialize.
    Link.ID;

    // Generate a URL text from a message.
    Link.GenerateMessage(string message);

    // Activate the tool with a URL.
    Link.Activate(string url);

```
</details>
<br>

## Platforms Setup
- ### Android
Add the following code to `AndroidManifest.xml` inside the `<application>` element:
```
<intent-filter>
    <action android:name="android.intent.action.VIEW" />
    <category android:name="android.intent.category.DEFAULT" />
    <category android:name="android.intent.category.BROWSABLE" />
    <data android:scheme="scheme" android:host="open" />
</intent-filter>
```
Replace scheme with your `scheme` had set it up in the game.

- ### IOS
1. Go to `Edit > Project Settings > Player > Other Settings > Configuration`
2. Expand `Supported URL schemes` and set the following properties:
    - Size: 1
    - Element 0: The URL `scheme` to use with your application.

<br>

## Webpage Setup
1. In the web machine create a file with your game name And Add the `index.html` in it.
2. Replace scheme with your `scheme` set up in the game.

<br>
<br>

### For any questions or inquiries, please contact Alaa@Shusmo.io
