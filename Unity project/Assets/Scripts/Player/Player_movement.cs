using UnityEngine;
public class Player_movement : MonoBehaviour {
    public static Player_movement _movement;

    private Player_input _input;

    private Rigidbody2D _rb;
    public static bool _paused;

    [Header("Atributtes")]
    [SerializeField] private float _speed = 3f;

    private void Awake() {
        _movement = this;

        _input = GetComponent<Player_input>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void HandleMovement() { 
        if (!_paused) {
            _rb.velocity = _input.MovementInput() * _speed;
        }         
    }

    public void PausePlayer(bool pause) {
        if (pause) {
            _paused = true;

            _rb.velocity = Vector2.zero;
        }
        else {
            _paused = false;
        }
    }

    #region Updates
    private void FixedUpdate() {
        HandleMovement();
    }
    #endregion
}