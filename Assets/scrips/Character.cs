using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
     private Rigidbody characterRigidbody;
     [SerializeField]
     private CharacterData characterData;
     [SerializeField]
     private Animator characternAnimator;
     [SerializeField]
     private float jumpForce = 5f;
    [SerializeField]
    private float distanceToMove = 2f;
    [SerializeField]
    private float moveDuration = 0.2f;
    private bool isGrounded = true;
    private bool isMoving = false;
    private void Start()
    {
        characternAnimator.Play(characterData.runAnimtionName, 0, 0f);
        characterRigidbody = GetComponent<Rigidbody>();
    }
    public void Jump()
    {
        if(isGrounded)
        {
            characternAnimator.Play(characterData.jumpAnimtionName, 0, 0f);
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void MoveDown()
    {
      if (!isGrounded)
     {
        characternAnimator.Play(characterData.jumpAnimtionName,0, 0f);
       characterRigidbody.AddForce (Vector3.down * jumpForce * 2, ForceMode.Impulse);
     }
     characternAnimator.Play(characterData.rollAnimtionName, 0, 0f);
    }
    public void MoveLeft()
    {
      Move(Vector3.left);
    }
    public void MoveRight()
    {
       Move (Vector3.right);
    }
    private void Move(Vector3 direction)
    {
      if (isMoving) return;
      characternAnimator.Play(characterData.moveAnimtionName, 0, 0f);
      isMoving = true;
      Vector3 targetPosition = transform.position + direction * distanceToMove;
      transform.DOMove (targetPosition, moveDuration). SetEase (Ease.OutQuad).OnComplete(() =>
      {
        isMoving = false;
      });
    }
    public void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            characternAnimator.Play(characterData.runAnimtionName, 0, 0f);
            isGrounded = true;
        }
    }



}
