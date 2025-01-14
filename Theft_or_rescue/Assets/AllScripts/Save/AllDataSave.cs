﻿using UnityEngine;

public class AllDataSave : MonoBehaviour//в awake копирует данные из серил файла
{
    public static AllDataSave instance { get; private set; }

    private Storage storage;
    private SavedData savedData;

    public int NumberAvatar;
    public int NumberCurrentWins;
    public int NumberTotalWins;
    public int NumberCurrentTotalWins;
    public int RemainingTimeBeforeWarning;
    public int NumberChance;
    public string GoldenAchievements;
    public string SilverAchievements;
    public int[] Characters;
    public int[] Things;
    public bool[] Answers;
    public int NumberBackground;
    public int NumberAnswer;
    public int RemainingNumberAttempts;
    public string LastAchievement;
    public int NumberCompletedGames;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        storage = new Storage();
        savedData = new SavedData();

        LoadAll();
    }
    private void OnApplicationQuit()
    {
        SaveAll();
    }
    public void SaveAll()
    {
        savedData.numberAvatart = NumberAvatar;
        savedData.numberCurrentWins = NumberCurrentWins;
        savedData.numberTotalWins = NumberTotalWins;
        savedData.numberCurrentTotalWins = NumberCurrentTotalWins;
        savedData.remainingTimeBeforeWarning = RemainingTimeBeforeWarning;
        savedData.numberChance = NumberChance;
        savedData.goldenAchievements = GoldenAchievements;
        savedData.silverAchievements = SilverAchievements;
        savedData.characters = Characters;
        savedData.answers = Answers;
        savedData.things = Things;
        savedData.numberBackground = NumberBackground;
        savedData.numberAnswer = NumberAnswer;
        savedData.remainingNumberAttempts = RemainingNumberAttempts;
        savedData.lastAchievement = LastAchievement;
        savedData.numberCompletedGames = NumberCompletedGames;

        storage.Save(savedData);
    }

#if UNITY_EDITOR
    [ContextMenu("Delete data")]
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();

        storage = new Storage();
        storage.DeleteData();

        Debug.Log("Данные удалены!");
    }
#endif
    public void NullAndSaveArraysData()
    { 
        Characters = null;
        Answers = null;
        Things = null;
    }
    public void NullAndSaveLevelData()
    {
        SaveCurrentTotalWins(0);
        SaveLastAcvievement(null);
        SaveCurrentWins(0);
        SaveCurrentWins(0);
        RemainingNumberAttempts = 0;
        NumberChance = 0;
        RemainingTimeBeforeWarning = 0;
    }
    public void LoadAll()
    {
        savedData = (SavedData)storage.Load(new SavedData());

        NumberAvatar = savedData.numberAvatart;
        NumberCurrentWins = savedData.numberCurrentWins;
        NumberTotalWins = savedData.numberTotalWins;
        NumberCurrentTotalWins = savedData.numberCurrentTotalWins;
        RemainingTimeBeforeWarning = savedData.remainingTimeBeforeWarning;
        NumberChance = savedData.numberChance;
        GoldenAchievements = savedData.goldenAchievements;
        SilverAchievements = savedData.silverAchievements;

        Characters = savedData.characters;
        Answers = savedData.answers;
        Things = savedData.things;
        NumberBackground = savedData.numberBackground;
        NumberAnswer = savedData.numberAnswer;
        RemainingNumberAttempts = savedData.remainingNumberAttempts;
        LastAchievement = savedData.lastAchievement;
        NumberCompletedGames = savedData.numberCompletedGames;
    }
    public void SaveCurrentTotalWins(int value)
    {
        NumberCurrentTotalWins = value;
        savedData.numberCurrentTotalWins = NumberCurrentTotalWins;
        storage.Save(savedData);
    }
    public void AddAndSaveNumberCompletedGames()
    {
        NumberCompletedGames++;
        savedData.numberCompletedGames = NumberCompletedGames;
        storage.Save(savedData);
    }
    public void SaveLastAcvievement(string lastAchiev)
    {
        LastAchievement = lastAchiev;
        savedData.lastAchievement = LastAchievement;
        storage.Save(savedData);
    }
    public void SaveRemainingNumberAttempts(int value)
    {
        RemainingNumberAttempts = value;
        savedData.remainingNumberAttempts = RemainingNumberAttempts;
        storage.Save(savedData);
    }
    public void SaveNumberAnswer(int num)
    {
        NumberAnswer = num;
        savedData.numberAnswer = num;
        storage.Save(savedData);
    }
    public void SaveDataLevel(int[] chars, int[] thins, bool[] answers, int numBackground)
    {
        Characters = chars;
        savedData.characters = Characters;
        Things = thins;
        savedData.things = Things;
        Answers = answers;
        savedData.answers = answers;
        NumberBackground = numBackground;
        savedData.numberBackground = numBackground;

        storage.Save(savedData);
    }
    public void ConfirmSelectedNumberAvatar(int number)
    {
        NumberAvatar = number;
        savedData.numberAvatart = NumberAvatar;
        storage.Save(savedData);
    }
    public void SaveCurrentWins(int number)
    {
        NumberCurrentWins = number;
        savedData.numberCurrentWins = NumberCurrentWins;
        storage.Save(savedData);
    }
    public void SaveTotalWins()
    {
        NumberTotalWins += NumberCurrentTotalWins;
        savedData.numberTotalWins = NumberTotalWins;
        storage.Save(savedData);
    }
    public void SaveRemainingTimeBeforeWarning(int value)
    {
        RemainingTimeBeforeWarning = value;
        savedData.remainingTimeBeforeWarning = RemainingTimeBeforeWarning;
        storage.Save(savedData);
    }
    public void SaveSecondChance(int chance )
    {
        NumberChance = chance;
        savedData.numberChance = NumberChance;
        storage.Save(savedData);
    }
    public void SaveGoldenAchievement(string achievement)
    {
        GoldenAchievements = achievement;
        savedData.goldenAchievements = GoldenAchievements;
        storage.Save(savedData);
    }
    public void SaveSilverAchievement(string achievement)
    {
        SilverAchievements = achievement;
        savedData.silverAchievements = SilverAchievements;
        storage.Save(savedData);
    }
}