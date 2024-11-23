using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using TMPro;

public class SpeechController : MonoBehaviour
{
    private ObjectSpawner spawner;
    public TextBubble textBubble;
    private EmoteController emoteController;

    string[] dialog = new string[]{ 
        "You are so valid!", 
        "You are doing a good job!", 
        "Take a rest every once in a while", 
        "I am very proud of you",
        "Have you been staying hydrated today?",
        "You've been sitting in one place for a while now!",
        "Come on! Let's get up and do some simple exercise",
        "You live for yourself and no one else",
        "Just hang in there a little longer!",
        "Would you like me to activate the de-stress filter for you?",
        "You seem tired, perhaps a little break?"
    };

    private void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();
    }
    public void TalkButton()
    {
        if (spawner != null)
        {
            TextBubble textBubble = spawner.GetComponentInChildren<TextBubble>();
            print("Button Pressed!");

            if (textBubble != null)
            {
                print("TextBubble not Null");
                int i = Random.Range(0, dialog.Length);
                string chosenDialog = dialog[i];
                textBubble.Speak(chosenDialog);
            }

        }
    }

}
