using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    // Start is called before the first frame update

    #region Editor

    [SerializeField] private GameObject _musicBoxPrefab;


    #endregion

    #region Fields

    private GameObject _musicBox;


    #endregion
    void Awake()
    {
        _musicBox = GameObject.FindWithTag("Music");
        if (_musicBox == null)
        {
            _musicBox = Instantiate(_musicBoxPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
