using UnityEngine;
using UnityEngine.Events;

public class FireHazard : MonoBehaviour
{
    private const string PlayerCharacterTag = "PlayerCharacter";

public event UnityAction<FireEnteredEventArgs> onCharacterEnteredAction;
    
    [HideInInspector] public FireHazardScriptableObject fireHazardData;

    [SerializeField]
    private UnityEvent<FireEnteredEventArgs> onCharacterEntered = new UnityEvent<FireEnteredEventArgs>();

    // public void SetScriptableData(FireHazardScriptableObject fireHazardScriptableObject)
    // {
    //     fireHazardData = fireHazardScriptableObject;
    // }
    // private void Start()
    // { 
    //     if(onCharacterEnteredAction != null)
    //        onCharacterEntered.AddListener(onCharacterEnteredAction);
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerCharacterTag))
        {
            Debug.Log("Player entered this hazard");
            FireEnteredEventArgs fireEnteredEventArgs = new FireEnteredEventArgs
            {
                damageDealt = fireHazardData.GetRandomFireDamage(),
                targetCharacterController = other.GetComponent<PlayerCharacterController>()
            };
            onCharacterEntered?.Invoke(fireEnteredEventArgs);
            onCharacterEnteredAction.Invoke(fireEnteredEventArgs);
        }
    }
}

public class FireEnteredEventArgs
{
    public int damageDealt;
    public PlayerCharacterController targetCharacterController;
}