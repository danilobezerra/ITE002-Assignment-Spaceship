using UnityEngine;

public abstract class Movement : MonoBehaviour {

    public abstract float speed { get; set; }

    public abstract void AplicarMovimentacao();
    
}
