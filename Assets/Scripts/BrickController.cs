using System;
using UnityEngine;
using UnityEngine.Events;

public class BrickController : MonoBehaviour
{
    public UnityEvent onBrickDestroyed;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player")) return;
        
        try
        {
            onBrickDestroyed.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine("Please, assign brick event " + e);
            throw;
        }
            
        Destroy(gameObject);

        //TODO: Remove these lines
        // var game = GamePlay.Instance;
        // game.Score++;
    }
}