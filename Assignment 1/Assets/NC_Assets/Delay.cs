using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    Animation Animated;
    public int Delay_timer;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DelayRoutine());
        Animated = GetComponent<Animation>();
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(Delay_timer);
        Animated.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
