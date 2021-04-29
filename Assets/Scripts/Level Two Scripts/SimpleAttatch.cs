using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleAttatch : MonoBehaviour
{
    private Interactable interactable;
    public GameObject hiddenItem;
    public AudioSource pickUpAudio;
    // Start is called before the first frame update
    void Start()
    {
        pickUpAudio.GetComponent<AudioSource>();
        hiddenItem.SetActive(true);
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //grab object

        if(interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }

        //Realse Object
        else if (isGrabEnding)
        {
            pickUpAudio.Play();
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
            hiddenItem.SetActive(false);

            if (hiddenItem.CompareTag("PickUp"))
            {
                ObjectFound.scoreValue += 1;
            }
            
            ObjectFound.scoreValue += 1;
            //add item counter here
        }
               
    }
}
