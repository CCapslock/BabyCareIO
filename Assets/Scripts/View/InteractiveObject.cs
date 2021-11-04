using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IExecute
{
    public static bool isInteraction = true;
    public static bool isThirdInteraction = true;
    
    protected abstract void Interaction();
    protected abstract void SecondInteraction();
    protected abstract void ThirdInteraction();
    protected abstract void FourthInteraction();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isInteraction)
            {
                return;
            }
            Interaction();

        } else if (other.CompareTag("PlacePlayer"))
        {
            SecondInteraction();
        }
        else if (other.CompareTag("FirstEnemyBabyBot"))
        {
            if (!isThirdInteraction)
            {
                return;
            }
            ThirdInteraction();
        }
        else if (other.CompareTag("PlaceFirstBot"))
        {
            FourthInteraction();
        }
    }
    public abstract void Execute();

}
