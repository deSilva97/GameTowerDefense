
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Utils.Raycast
{
    public class RaycastDetector<T> where T : class
    {
        LayerMask _layers;

        public RaycastDetector(LayerMask? layers = null) {
            _layers = layers?.value ?? ~0;
        }

        public List<T> MultipleLineDetection(Vector3 origin, Vector2 direction, float distance)
        {
            var hits = Physics2D.RaycastAll(origin, direction, distance, _layers);
            Debug.Log("hits"+ string.Join(", ", hits));
            var results = hits
                .Select(hit => hit.collider.GetComponent<T>())
                .Where(component => component != null)
                .ToList();

            Debug.Log("results"+string.Join(", ", results));
            return results;
        }
        
    }
    public class RaycastDetectorDeprecated<T> where T : class
    {
        Collider2D selfCollider = null;

        public RaycastDetectorDeprecated(Collider2D selfCollider = null)
        {
            this.selfCollider = selfCollider;
        }

        public List<T> MultipleLineDetection(Vector3 origin, Vector2 direction, float distance, ICollection<string> ignoreTags = null, LayerMask? layers = null)
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            var tags = ignoreTags ?? new List<string>();

            int mask = layers?.value ?? ~0;
            var hits = Physics2D.RaycastAll(origin, direction, distance, mask);
            var results = hits
                .Where(hit => (selfCollider == null || hit.collider != selfCollider) && (!tags.Contains(hit.collider.tag)))
                .Select(hit => hit.collider.GetComponent<T>())
                .Where(component => component != null)
                .ToList();

            // Debug.Log($"Hits totales: {hits.Count()}");
            // Debug.Log($"Results totales: {results.Count}");

            // if (results.Count > 0)
            //     Debug.Log($"Colision de {origin} con: " + string.Join(", ", results.Select(x => x.ToString())));

            return results;
        }

        public T SingleLineDetection(Vector3 origin, Vector2 direction, float distance, LayerMask? layers = null)
        {
            Debug.DrawRay(origin, direction * distance, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, layers ?? new LayerMask());

            if (hit.collider != null && hit.collider != selfCollider)
            {
                Debug.Log("Colisi�n con: " + hit.collider.name);
                return hit.collider.GetComponent<T>();
            }

            return default;
        }
    }
}
