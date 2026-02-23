using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowHazard : MonoBehaviour
{
    private const string ArrowPath = "ArrowObject";
    
    //public GameObject arrowPrefab;
    private static ObjectPool<ArrowObject> arrowPool;
    [SerializeField] private float arrowTimeAlive;
    [SerializeField] private float shootInterval;
    private float shootIntervalLeft;

    private void Awake()
    {
        if (arrowPool == null)
        {
            arrowPool = new ObjectPool<ArrowObject>(() =>
            {
                ArrowObject arrow = Instantiate(Resources.Load<ArrowObject>(ArrowPath));
                return arrow;
            }, arrow =>
            {
                arrow.gameObject.SetActive(true);
            }, arrow =>
            {
                arrow.gameObject.SetActive(false);
            }, arrow =>
            {
                Destroy(arrow.gameObject);
            }, false, 10, 100);
        }
        shootIntervalLeft = shootInterval;
    }

    // Update is called once per frame
    private void Update()
    {
        shootIntervalLeft -= Time.deltaTime;
        if (!(shootIntervalLeft <= 0)) return;
        
        ArrowObject arrow = arrowPool.Get();
        arrow.transform.position = transform.position;
        arrow.transform.rotation = Quaternion.Euler(0, 180, 0);
        //ArrowObject arrow = Instantiate(arrowPrefab,transform.position,Quaternion.identity).GetComponent<ArrowObject>();
        //arrow.transform.Rotate(0,90,0);
        //arrow.transform.Rotate(0,90,0);
        shootIntervalLeft = shootInterval;
        StartCoroutine(ReturnAfter(arrow, 3f));
    }
    
    private static IEnumerator ReturnAfter(ArrowObject arrow, float time)
    {
        yield return new WaitForSeconds(time);
        arrowPool.Release(arrow);
    }
}