using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TextBubble : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private Camera mainCamera;
    public Image background;
    public CanvasGroup bubbleGroup;
    public Vector2 padding = new Vector2(2, 2);

    private void Start()
    {
        mainCamera = Camera.main;
        textMeshPro = GetComponentInChildren<TextMeshPro>(); 
        if (textMeshPro != null)
        {
            textMeshPro.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
            print("textmeshpro not null");
        }

    }
    private void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
            transform.Rotate(0, 180, 0); 
        }
    }

    public void Speak(string text)
    {
        textMeshPro.text = text;
        print("Textbox Spawned");
        UpdateBackground();
        StartCoroutine(FadeInOut());
    }

    private System.Collections.IEnumerator FadeInOut()
    {
        textMeshPro.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        bubbleGroup.alpha = 0;
        while (bubbleGroup.alpha < 1)
        {
            bubbleGroup.alpha += Time.deltaTime / 0.5f;
            yield return null;
        }
        bubbleGroup.alpha = 1;
        yield return new WaitForSeconds(3);
        while (bubbleGroup.alpha > 0)
        {
            bubbleGroup.alpha -= Time.deltaTime / 1f;
            yield return null;
        }
        bubbleGroup.alpha = 0;
        textMeshPro.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    private void UpdateBackground()
    {
        float textWidth = textMeshPro.preferredWidth + padding.x * 2; // Adding padding
        float textHeight = textMeshPro.preferredHeight + padding.y * 2; // Adding padding
        background.rectTransform.sizeDelta = new Vector2(textWidth, textHeight);
    }
}
