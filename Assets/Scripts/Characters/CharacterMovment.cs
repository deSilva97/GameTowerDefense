using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.Raycast;

namespace Game.Character
{
    public class CharacterMovment : MonoBehaviour
    {
        public enum MovmentStatus : byte {Healty, Stunned}

        [SerializeField] GameLookAtDirection _movmentDirection;
        [SerializeField] CharacterStatsHolder _holder;

        [SerializeField] float distanceDetection = 1;

        public GameLookAtDirection MovmentDirection { get => _movmentDirection; set => _movmentDirection = value; }

        public RaycastDetector<Collider2D> _detector;

        public MovmentStatus Status { get; private set; } = MovmentStatus.Healty;
        public List<Collider2D> Detections { get; private set; } = new List<Collider2D>();

        public bool CanMove() => Status.Equals(MovmentStatus.Healty) && Detections.Count == 0;

        void Start()
        {
            _detector = new RaycastDetector<Collider2D>();
        }

        private void Update()
        {
            TryToMove();
        }
        void Move()
        {
            if (!CanMove())
                return;

            transform.Translate(Vector2.right * (int)MovmentDirection * Time.deltaTime * _holder.MovmentSpeed.CurrentValue);
        }
        void TryToMove()
        {
            var detections = _detector.MultipleLineDetection(
                origin: transform.position + Vector3.up,
                direction: Vector2.right * (int)MovmentDirection,
                distance: distanceDetection
            );

            var filteredDetections = detections
                .Where(x => x.gameObject != gameObject && !x.gameObject.CompareTag(gameObject.tag))
                .ToList();

            Detections = filteredDetections;

            Move();
        }
    }
    
}

