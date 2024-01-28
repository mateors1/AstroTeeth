
using UnityEngine;

public class ReactionHandler : MonoBehaviour
{
   
    


    void OnTriggerExit2D(Collider2D other)
    {
        TriggerChatEvent(other.tag.ToLower());
    }

    void TriggerChatEvent(string tag)
    {
        switch (tag)
        {
            
            case "duck": CatFollowerRandomAnswer.onPowerup1?.Invoke();
                break;
            
            case "obstacle": CatFollowerRandomAnswer.onHelpfulAdvice?.Invoke();
                break;
            case "planet": CatFollowerRandomAnswer.onPowerup2.Invoke();
                break;
            case "random": CatFollowerRandomAnswer.onPowerup3.Invoke();
                break;
        }
    }
}
