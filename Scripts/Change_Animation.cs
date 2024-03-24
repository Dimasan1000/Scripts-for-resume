using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using AppodealAds.Unity.Api;

public class Change_Animation : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private Counter _chekCulbit;
    [SerializeField] private string[] _culbits = new string[4];
    [SerializeField] private string[] _animations = new string[2];
    [SerializeField] private All_Timers _pause;
    public bool _flagDie = false;
    public bool _flagAnimBonus;
    [SerializeField] private Image _everyDayBonus;
    [SerializeField] private GameObject objImage;
    [SerializeField] private Button _culbitButton;
    [SerializeField] private PlayADV RevCulbit;
    [SerializeField] private TextMeshProUGUI _cristals;

    public void Update()
    {
        if (objImage.activeSelf == true)
            AnimBonusButton();
    }

    public void AnimChange()
    {
        Appodeal.cache(Appodeal.REWARDED_VIDEO);
        animator.SetBool("Stay", true);
    }

    public void ChangeCulbit()
    {
        _culbitButton.gameObject.SetActive(false);
        _culbitButton.transform.GetChild(1).gameObject.SetActive(false);
        StartCoroutine(ChoiseCulbite());
    }

    private IEnumerator ChoiseCulbite()
    {
        int _countCulbit = UnityEngine.Random.Range(0, _culbits.Length);
        animator.applyRootMotion = false;
        animator.SetBool(_culbits[_countCulbit], true);
        yield return new WaitForSeconds(0.5f);
        animator.gameObject.transform.position = animator.gameObject.transform.parent.transform.position;
        animator.applyRootMotion = true;
        animator.SetBool(_culbits[_countCulbit], false);

        if (_chekCulbit._chekBonusCulbit == true)
        {
            _chekCulbit._countCoin += 50;
            RevCulbit.CheckText(true, 50.ToString());
            _chekCulbit._coinsToMenu.text = _chekCulbit._coins.text = _chekCulbit._countCoin.ToString();
            Debug.Log("Get Bonus" + _chekCulbit._chekBonusCulbit);
        }
        _chekCulbit._chekBonusCulbit = true;

    }

    public void StartAnimDamage()
    {
        StartCoroutine(AnimDamage());
    }

    private IEnumerator AnimDamage()
    {
        animator.SetBool(_animations[0], true);
        yield return new WaitForSeconds(0);
        animator.SetBool(_animations[0], false);
    }

    public void StartAnimDie()
    {
        StartCoroutine(AnimDie());
    }

    private IEnumerator AnimDie()
    {

        animator.SetBool(_animations[1], true);
        
            RevCulbit._mnozhCristal = (Convert.ToInt32(RevCulbit._playerPosZ.transform.position.z) / 400);
            RevCulbit._mnozhCristal++;
            RevCulbit._priseRaRan.text = (25 * RevCulbit._mnozhCristal).ToString();
            Debug.Log(25*RevCulbit._mnozhCristal);
        yield return new WaitForSeconds(1.4f);
        if (_flagDie == false)
        {
            Debug.Log("Play Animation" + _flagDie);
            _pause.OnPauseRan();
            _cristals.text = _chekCulbit._cristalMenu.text;
            _cristals.transform.parent.gameObject.SetActive(true);
            _chekCulbit._death.DieScreen();
           
                _flagDie = true;
            // Debug.Log("Play Animation"+_flagDie);
        }
    }

    public void ResetSwim()
    {
       // _pause.OffPauseRan();
        animator.SetBool(_animations[1], false);
        _cristals.transform.parent.gameObject.SetActive(false);
    }

    /// <summary>
    /// Animation Rotation and Scale.
    /// </summary>
    public void AnimBonusButton()
    {
        Quaternion imagebonus = _everyDayBonus.transform.localRotation;
        imagebonus *= Quaternion.Euler(new Vector3(0, 0, 0.5f));
        _everyDayBonus.transform.localRotation = imagebonus;
        Vector3 _scalebonus = _everyDayBonus.transform.localScale;
        if (_scalebonus.x >= 60 && _flagAnimBonus == false)
        {
            _scalebonus.x -= 0.5f;
            _scalebonus.y = _scalebonus.x;
            _everyDayBonus.transform.localScale = _scalebonus;
            if (_scalebonus.x < 61)
                _flagAnimBonus = true;
        }
        if (_scalebonus.x <= 100f && _flagAnimBonus == true)
        {
            _scalebonus.x += 0.5f;
            _scalebonus.y = _scalebonus.x;
            _everyDayBonus.transform.localScale = _scalebonus;
            if (_scalebonus.x > 99)
                _flagAnimBonus = false;
        }
    }
    public void SpeedClip()
    {
        Time.timeScale +=1 ;
    }
}
