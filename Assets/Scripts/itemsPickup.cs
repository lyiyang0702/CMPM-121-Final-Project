using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsPickup : MonoBehaviour
{
    public items item;
    public ParticleSystem particle;
    [SerializeField]
    float distance = 1f;
    public Transform player;
    private void Start()
    {
        particle.Stop();
        GameManager.instance.onItemsChanged += onItemsChanged;
        
    }
    void FixedUpdate()
    {
        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = false;
        float Distance = Vector3.Distance(player.position, transform.position);
        if (Distance < distance)
        {
            wasPickedUp = GameManager.instance.Add(item);
        }

        if (wasPickedUp)
        {
            particle.Play();
            StartCoroutine(stopParticle());
            Destroy(gameObject);
            return;
        }
    }

    void onItemsChanged()
    {
        if (GameManager.instance.items.Count == 4)
        {
            GameManager.instance.GameEnd();
        }
    }


    IEnumerator stopParticle()
    {
        yield return new WaitForSeconds(.4f);
        particle.Stop();
    }
}
