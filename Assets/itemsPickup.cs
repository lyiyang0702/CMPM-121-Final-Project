using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsPickup : MonoBehaviour
{
    public items item;
    [SerializeField]
    float distance = 1f;
    public Transform player;
    [SerializeField]
    ParticleSystem CollectParticle;
    private void Start()
    {
        CollectParticle.Stop();
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
            Destroy(gameObject);
            return;
        }
    }

    void onItemsChanged()
    {
        CollectParticle.Play();
        CollectParticle.Stop();
        if (GameManager.instance.items.Count == 4)
        {
            GameManager.instance.GameEnd();
        }
    }
}
