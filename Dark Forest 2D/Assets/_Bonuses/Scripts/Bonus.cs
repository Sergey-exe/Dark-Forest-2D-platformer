using UnityEngine;
using UnityEngine.Events;

public abstract class Bonus : MonoBehaviour 
{
    [field: SerializeField] public int Denomination { get; private set; }

    public event UnityAction<Bonus> OnPickUp;

    public void PickUp()
    {
        OnPickUp?.Invoke(GetComponent<Bonus>());
    }
}
