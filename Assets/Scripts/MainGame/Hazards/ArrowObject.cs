using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public float speed;
    public float damage;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}