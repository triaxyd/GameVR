using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : NPCBase
{
    [SerializeField]
    private bool followPlayer;

    [SerializeField]
    private bool followFriends;

    public void SetFollowFriends(bool value)
    {
        followFriends = value;
    }

    public void SetFollowPlayer(bool value)
    {
        followPlayer = value;
    }


    public override string InteractionPrompt
    {
        get
        {
            if (!followPlayer && !followFriends) return "Lonely Guy: \"I miss my friends.. Will you take me back to them?\"\nPress [E] to make lonely guy follow you";
            else if (followPlayer && !followFriends) return "Lonely Guy: \"I'm following you...\"";
            else if (!followPlayer && followFriends) return "Lonely Guy: \"Thank you for showing me the way!\"";
            else return "";
        }
    }

    public override bool Interact(Interactor interactor)
    {
        if (!followPlayer && !followFriends)
        {
            Debug.Log("NPC is now following!");
            followPlayer = true;
            this.gameObject.GetComponent<MoveNPC>().enabled = true;
            this.gameObject.GetComponent<Patrol>().enabled = false;            
            return true;
        }
        else if (followPlayer && !followFriends)
        {
            Debug.Log("NPC is still following!!!!");
            //followFriends = false;
            //followPlayer = true;
            //this.gameObject.GetComponent<MoveNPC>().enabled = true;
            //this.gameObject.GetComponent<Patrol>().enabled = false;
            return true;
        }
        return false;
    }

    private void Start()
    {
        this.gameObject.GetComponent<MoveNPC>().enabled = false;
        this.gameObject.GetComponent<Patrol>().enabled = false;
        followPlayer = false;
        followFriends = false;
    }
}
