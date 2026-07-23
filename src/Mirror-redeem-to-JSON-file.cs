using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CPHInline
{
    public bool Execute()
    {
        // ================= SETTINGS =================

        string parentFolderName = "Omanges Extensions";
        string dataFolderName = "First";

        string leaderboardFileName = "FirstLeaderboard.json";
        string historyFileName = "FirstHistory.json";

        // Reserved for future use
        // true = save timestamps
        // false = save dates only
        bool trackTime = false;

        // ================= END SETTINGS =================


        // Get username
        string userName = "";

        if (args.ContainsKey("userName"))
            userName = args["userName"].ToString().ToLower();

        if (string.IsNullOrEmpty(userName))
            return false;


        // Build directory path
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        string folderPath = Path.Combine(
            baseDir,
            parentFolderName,
            dataFolderName
        );


        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);


        string leaderboardPath = Path.Combine(
            folderPath,
            leaderboardFileName
        );

        string historyPath = Path.Combine(
            folderPath,
            historyFileName
        );


        // ==================================================
        // LEADERBOARD UPDATE
        // ==================================================


        Dictionary<string, UserData> leaderboard =
            new Dictionary<string, UserData>();


        if (File.Exists(leaderboardPath))
        {
            string json = File.ReadAllText(leaderboardPath);

            try
            {
                // New format
                leaderboard =
                    JsonConvert.DeserializeObject<Dictionary<string, UserData>>(json)
                    ?? new Dictionary<string, UserData>();
            }
            catch
            {
                // Convert old format:
                // {
                //   "digitalowen": 2
                // }

                Dictionary<string, int> oldLeaderboard =
                    JsonConvert.DeserializeObject<Dictionary<string, int>>(json)
                    ?? new Dictionary<string, int>();


                foreach (var entry in oldLeaderboard)
                {
                    leaderboard[entry.Key] = new UserData
                    {
                        count = entry.Value
                    };
                }
            }
        }


        if (!leaderboard.ContainsKey(userName))
        {
            leaderboard[userName] = new UserData
            {
                count = 0
            };
        }


        leaderboard[userName].count++;


        File.WriteAllText(
            leaderboardPath,
            JsonConvert.SerializeObject(
                leaderboard,
                Formatting.Indented
            )
        );


        // ==================================================
        // HISTORY UPDATE
        // ==================================================


        Dictionary<string, List<string>> history =
            new Dictionary<string, List<string>>();


        if (File.Exists(historyPath))
        {
            history =
                JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(
                    File.ReadAllText(historyPath)
                )
                ?? new Dictionary<string, List<string>>();
        }


        string today;

        if (trackTime)
        {
            today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else
        {
            today = DateTime.Now.ToString("yyyy-MM-dd");
        }


        // When tracking time, history still groups by date
        string historyDate = DateTime.Now.ToString("yyyy-MM-dd");


        if (!history.ContainsKey(historyDate))
        {
            history[historyDate] = new List<string>();
        }


        // Prevent duplicate same-user same-day entries
        if (!history[historyDate].Contains(userName))
        {
            history[historyDate].Add(userName);
        }


        File.WriteAllText(
            historyPath,
            JsonConvert.SerializeObject(
                history,
                Formatting.Indented
            )
        );


        CPH.LogInfo(
            $"First saved: {userName}"
        );


        return true;
    }



    public class UserData
    {
        public int count { get; set; }
    }
}
