using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IExecute
{
    
    protected abstract void Interaction();
    protected abstract void SecondInteraction();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction();
        }else if (other.CompareTag("PlacePlayer"))
        {
            SecondInteraction();
        }
    }
    public abstract void Execute();

}
