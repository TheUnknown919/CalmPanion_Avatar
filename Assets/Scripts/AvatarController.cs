using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using TMPro;

public class AvatarController : MonoBehaviour
{
    private ObjectSpawner spawner;
    public TextBubble textBubble;
    private EmoteController emoteController;
    private bool standing;

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

    string[] emote = new string[]
    {   
        "Wave",
        "Rally",
        "Cheer",
        "Clap",
        "HipHop",
        "Salsa",
        "Swing"
    };

    private void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();
        standing = true;
    }
    public void BigButton()
    {
        if (spawner != null)
        {
            TextBubble textBubble = spawner.GetComponentInChildren<TextBubble>();
            print("Button Pressed!");

            if (textBubble != null)
            {
                int i = Random.Range(0, dialog.Length);
                string chosenDialog = dialog[i];
                textBubble.Speak(chosenDialog);
            }

            RandomEmote();

        }
    }
    private void ExecuteTrigger(string trigger)
    {
        if (spawner.prefabClone != null)
        {
            print("prefabclone not null");
            var animator = spawner.prefabClone.GetComponent<Animator>();
            if (animator != null)
            {
                print("Attempting to Play Animator");
                animator.SetTrigger(trigger);
            }
            else
            {
                print("Animator is Null");
            }
        }
    }
    public void RandomEmote()
    {
        int w = Random.Range(0, emote.Length);
        string chosenEmote = emote[w];
        Emote(chosenEmote);
        print(chosenEmote);
    }
    public void Emote(string emoteName)
    {
        print("emote trigger");
        ExecuteTrigger(emoteName);
    }

    public void Toggle()
    {
        if (standing)
        {
            ExecuteTrigger("Sit");
            standing = false;
        }
        else
        {
            ExecuteTrigger("Stand");
            standing = true;
        }
    }

}
