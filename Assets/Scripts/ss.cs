using UnityEngine;

public class ss : MonoBehaviour
{
    public Camera screenshotCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CaptureScreenshot();
        }
    }

    void CaptureScreenshot()
    {
        // Capture screenshot
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        screenshotCamera.targetTexture = renderTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshotCamera.Render();
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Save the screenshot as an image file
        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/Icons/ItemIcon.png", bytes);

        // Clean up
        RenderTexture.active = null;
        screenshotCamera.targetTexture = null;
        Destroy(renderTexture);
    }
}