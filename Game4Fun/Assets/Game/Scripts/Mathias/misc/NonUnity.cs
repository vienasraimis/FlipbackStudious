using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class Level
{
    public int index = 0;
    public string SceneName = "";

    public bool unlocked = false;
}

[System.Serializable]
public class LevelBuilder
{
    public string[] levelNames;

    public List<Level> Build()
    {
        if (PlayerPrefs.GetString("UnlockedLevels") == "") return BuildClean();

        List<Level> levels = new List<Level>();
        string[] scenes = PlayerPrefs.GetString("UnlockedLevels").Split('|');

        int indexer = 0;
        foreach (var level in levelNames)
        {
            Level lvl = new Level();
            lvl.SceneName = level;
            lvl.index = indexer;

            if (scenes.Contains(level)) lvl.unlocked = true;

            levels.Add(lvl);

            indexer++;
        }

        return levels;
    }

    private List<Level> BuildClean()
    {
        List<Level> levels = new List<Level>();

        int indexer = 0;
        foreach (var level in levelNames)
        {
            Level lvl = new Level();
            lvl.SceneName = level;
            lvl.index = indexer;

            if (indexer == 0) lvl.unlocked = true;

            levels.Add(lvl);

            indexer++;
        }

        return levels;
    }

    public void Save(List<Level> levels)
    {
        string buildString = "";
        foreach (var lvl in levels)
        {
            buildString = lvl.SceneName + "|";
        }

        PlayerPrefs.SetString("UnlockedLevels", buildString);
        PlayerPrefs.Save();
    }
}