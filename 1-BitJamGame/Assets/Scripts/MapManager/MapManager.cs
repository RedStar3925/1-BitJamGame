using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [Header("prefab")]
    [SerializeField] private GameObject[] _parentObj;
    [SerializeField] private GameObject[] _topSideMapObj;
    [SerializeField] private GameObject[] _botSideMapObj;
    [Header("option")]
    [SerializeField] private bool _isScreenSizeReference; 
    [SerializeField] private float _parentOneXPositionStart;
    [SerializeField] private float _parentTwoXPositionStart;
    [SerializeField] private float _xPositionToReset;
    [SerializeField] private float _scrollingSpeed;
    [SerializeField] private float _topsideHeight;
    [SerializeField] private float _botsideHeight;

    private Vector3 _positionPlusSpeed;
    private Vector3 _topSidePosition;
    private Vector3 _botSidePosition;
    private Transform _nextParent;

    public float GetScrollingSpeed() => _scrollingSpeed;
    public Transform GetNextParent() => _nextParent;


    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        InitializeMapManager();
    }
    private void Update() 
    {        

        foreach (var item in _parentObj)
        {
            //item.transform.position += _positionPlusSpeed;
            ScrollMap(item.transform);
            InitializeNextMapSegment(item.transform);
            // if(item.transform.position.x <= _xPositionToReset)   
            // {
            //     CleanChildren(item.transform);
            //     item.transform.position = new Vector3(_parentTwoXPositionStart,0,0);
            //     GameObject topsideprefab = Instantiate(_topSideMapObj[0], item.transform.position + _topSidePosition, Quaternion.identity, item.transform);
            //     GameObject botsideprefab = Instantiate(_botSideMapObj[0], item.transform.position + _botSidePosition, Quaternion.identity, item.transform);
            // } 
        }

    }
    private void InitializeNextMapSegment(Transform trm)
    {
        if(trm.position.x <= _xPositionToReset)   
            {
                CleanChildren(trm);
                trm.position = new Vector3(_parentTwoXPositionStart,0,0);
                GameObject topsideprefab = Instantiate(_topSideMapObj[0], trm.position + _topSidePosition, Quaternion.identity, trm);
                GameObject botsideprefab = Instantiate(_botSideMapObj[0], trm.position + _botSidePosition, Quaternion.identity, trm);
                _nextParent = trm;
            } 
    }
    private void ScrollMap(Transform trm)
    {
        trm.position += _positionPlusSpeed;
    }
    private void InitializeMapManager()
    {
        ChangeScrollingSpeed(_scrollingSpeed);
        _parentObj[0].transform.position = new Vector3(_parentOneXPositionStart,0,0);
        _parentObj[1].transform.position = new Vector3(_parentTwoXPositionStart,0,0);
        _topSidePosition = new Vector3(0,_topsideHeight,0);
        _botSidePosition = new Vector3(0,_botsideHeight,0);
    }
    private void ChangeScrollingSpeed(float spd)
    {
        _scrollingSpeed = spd * Time.deltaTime;
        _positionPlusSpeed = new Vector3(_scrollingSpeed,0,0);
    }

    private void CleanChildren(Transform parent)
    {
        foreach (Transform obj in parent.transform)
        {
            Destroy(obj.gameObject);
        }
    }
}
