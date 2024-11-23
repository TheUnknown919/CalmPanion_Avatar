using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class EmoteController : MonoBehaviour
{
    private ObjectSpawner spawner;
    private bool standing;

    //string[] emote = new string[]
    //{
    //    "Rally",
    //    "Walk",
    //    "Sit",
    //    "Stand"
    //};

    private void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();
        standing = true;
    }
    private void ExecuteTrigger(string trigger)
    {
        if(spawner.prefabClone != null)
        {
            print("prefabclone not null");
            var animator = spawner.prefabClone.GetComponent<Animator>();
            if(animator != null)
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

    //public void RandomEmote()
    //{
    //    int w = Random.Range(0, emote.Length);
    //    string chosenEmote = emote[w];
    //    Emote(chosenEmote);
    //}
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
