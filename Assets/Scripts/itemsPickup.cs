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

    [SerializeField] private AudioSource doorUnlock;
    [SerializeField] private AudioSource doorCreak;
    [SerializeField] private AudioSource pickup;


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
            pickup.Play();
            particle.Play();
            StartCoroutine(stopParticle());
            Destroy(gameObject);
            return;
        }
    }

    void onItemsChanged()
    {
        int itemCount = GameManager.instance.items.Count;
        UIScript.instance.ChangeText(itemCount + 1);
        if ( itemCount == 4)
        {
            GameManager.instance.GameEnd();
            doorCreak.Play();
            doorUnlock.Play();
        }
    }


    IEnumerator stopParticle()
    {
        yield return new WaitForSeconds(.4f);
        particle.Stop();
    }
}
