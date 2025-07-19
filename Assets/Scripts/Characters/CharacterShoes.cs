using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.Raycast;

public record CharacterShoesContext
{
    // public Transform Body { get; set; } 
    // public Collider2D BodyCollider { get; set; } = null;
    // public float Speed { get; set; } = 1;

    // public List<string>? IgnoreTags { get; set; } = null;
    // public LayerMask IgnoreLayers { get; set; } = ~0;
}

public class CharacterShoes
{
    // public CharacterShoesContext Context { get; private set; }
    
    // public RaycastDetector<IDetectable> Detector { get; private set; }

    // public CharacterShoes(CharacterShoesContext context)
    // {
    //     Context = context;
    //     Detector = new RaycastDetector<IDetectable>(context.BodyCollider);
    // }

    // public void TryToMove(MovmentDirection direction)
    // {
    //     var detections = Detector.MultipleLineDetection(
    //             Context.Body.position + Vector3.up, Vector2.right * (int)direction, 1f, Context.IgnoreTags, Context.IgnoreLayers);
    //     if (detections.Count() == 0)
    //     {
    //         Context.Body.Translate((int)direction * Context.Speed * Time.deltaTime, 0, 0);
    //         Debug.Log($"Moviendo porque {detections.Count}");
    //     }
    //     else
    //     {
    //         Debug.Log($"{Context.Body.name}: Hay algo en mi camino!");
    //     }
    // }

}
