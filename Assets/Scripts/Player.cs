using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private int moveSpeed = 7;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private LayerMask countersLayerMask;

    private bool isWalking;
    private Vector3 lastInteractDir;

    private ClearCounter selectedCounter;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There if no more Player instance");
        }
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
        {
            selectedCounter.Interact();
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormilized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                if(clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormilized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 1.9f;
        bool canMove = !Physics.CapsuleCast(transform.position,
                                            transform.position + Vector3.up * playerHeight,
                                            playerRadius,
                                            moveDir,
                                            moveDistance);
        if (!canMove)
        {
            Vector2 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position,
                                            transform.position + Vector3.up * playerHeight,
                                            playerRadius,
                                            moveDirX,
                                            moveDistance);

            if (canMove)
            {
                //Can move  only on the X
                moveDir = moveDirX;

            }
            else
            {
                //Cant move only on the X
                //Attempt only Z movement

                Vector2 moveDirZ = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position,
                                                transform.position + Vector3.up * playerHeight,
                                                playerRadius,
                                                moveDirZ,
                                                moveDistance);
                if (canMove)
                {
                    //Can move only on the Z
                    moveDir = moveDirZ;

                }
                else
                {
                    //Cannot move in any direction
                }

            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
       this.selectedCounter = selectedCounter;

       OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
       {
              selectedCounter = selectedCounter
       });
    }
}
