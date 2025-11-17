/*
 * 1)
 * Names: Tom Moore and Sammy Rokaw
 * Emails: thomoore@chapman.edu rokaw@chapman.edu
 * ID: Tom: 2444464 Sammy: 2444664
 * Course: GAME245-01
 * Assignment 3
 *
 * 2)
 * This file is used to make evnets for the states manager to call
 */
using UnityEngine;
using System;

public class UIEvents : MonoBehaviour
{
    public static Action ChangeToMState;
    public static Action ChangeToRState;
    public static Action ChangeToQState;

    public UI ui;
    public AudioClip lobbyTrack;
    public AudioClip questionTrack;

    public void OnEnable()
    {
        Subscribe();
    }

    public void OnDisable()
    {
        Unsubscribe();
    }

    public void Subscribe()
    {
        ChangeToMState += MState;
        ChangeToRState += RState;
        ChangeToQState += QState;
    }

    public void Unsubscribe()
    {
        ChangeToMState -= MState;
        ChangeToRState -= RState;
        ChangeToQState -= QState;
    }

    private void MState()
    {
        ui.GoToStart();
    }
    private void RState()
    {
        ui.HidesGame();
        ui.ShowsGameResults();
        SoundManager.Instance.switchBackGroundTrackWithFade(lobbyTrack);
    }
    private void QState()
    {
        ui.stopButtons();
        SoundManager.Instance.switchBackGroundTrackWithFade(questionTrack);
        ui.HidesSG();
        ui.HidesGameResults();
        ui.ShowsGame();
    }
}
