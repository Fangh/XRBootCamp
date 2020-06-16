using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BouncingCube : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] posList;

    [Header("Settings")]
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float jumpSpeed = 0.4f;
    [SerializeField] private float timeBetweenJump = 1f;

    private MeshRenderer myRenderer;

    private void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        BounceRandom();
    }

    private void BounceRandom()
    {
        Transform nextPos = posList[Random.Range(0, posList.Length)];
        Vector3 jumpPos = transform.position + (nextPos.position - transform.position) * 0.5f;
        jumpPos.y = jumpHeight;
        transform.DOMove(jumpPos, jumpSpeed).SetDelay(timeBetweenJump).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            transform.DOMove(nextPos.position, jumpSpeed).SetEase(Ease.InQuart).OnComplete(() =>
            {
                ChangeColor();
                BounceRandom();
            });
        });
    }

    private void ChangeColor()
    {
        Color rndColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        myRenderer.material.SetColor("_Color", rndColor);
    }
}
