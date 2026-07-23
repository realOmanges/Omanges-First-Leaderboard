# 🏆 Omanges First With Leaderboard

**Omanges First With Leaderboard** is a Streamer.bot extension that turns a Twitch **First** channel-point redemption into a persistent leaderboard and redemption history.

It tracks each viewer’s total wins, records the winner for each stream date, supports paginated leaderboard results, and allows viewers to look up their own stats.

---

## 🎯 Key Features

- 🏆 **Persistent First Leaderboard**  
  Tracks how many times each viewer has redeemed First.

- 📅 **Date-Based Redemption History**  
  Records the First winner for each stream date.

- 📊 **Paginated Leaderboard Command**  
  View page 1 or request a specific page of leaderboard results.

- 👤 **Viewer Stat Lookup**  
  Viewers can check their own stats, while authorized users can look up another viewer.

- 🔐 **Configurable Permissions**  
  Control who can use commands and who can search for other users directly inside Streamer.bot.

- 💬 **Customizable Messages**  
  Adjust leaderboard, lookup, error, and permission messages through action arguments.

- 🔄 **Automatic Reward Reset Support**  
  Includes actions for preparing the First reward for the next stream.

---

## 🧰 Requirements

- [Streamer.bot](https://streamer.bot) **1.0.0-alpha.1 or newer**
- A Twitch account connected to Streamer.bot
- A Twitch channel-point reward for the First redemption

---

## 📦 Installation

### 1. Download the Extension

Download the latest `.sb` file from the [`releases`](releases/) folder in this repository.

### 2. Import into Streamer.bot

1. Open Streamer.bot.
2. Click **Import**.
3. Drag the downloaded `.sb` file into the import window.
4. Complete the import.

The imported main action group is named:

```text
Omanges - First with Leaderboard
```

### 3. Assign the Channel-Point Reward

Create or select your Twitch First reward, then assign it to the imported First redemption action.

Review the imported reset action and assign the same reward where indicated.

### 4. Review Command Permissions

Before enabling the commands, review the permission-related arguments in each command action.

Detailed installation steps are available in [`docs/SETUP.md`](docs/SETUP.md).

---

## 💬 Commands

| Command | Description |
|---|---|
| `!firstleaderboard` | Displays page 1 of the First leaderboard. |
| `!firstleaderboard 2` | Displays the requested leaderboard page. |
| `!firstleader` | Alias for `!firstleaderboard`. |
| `!firstleaders` | Alias for `!firstleaderboard`. |
| `!firstme` | Displays the requesting viewer’s First statistics. |
| `!firstme @username` | Looks up another viewer when the requester has permission. |

---

## ⚙️ Configuration

The extension’s messages and permission settings are configured through arguments in the imported Streamer.bot actions.

You can customize items such as:

- Leaderboard title and formatting
- Number of users shown per page
- Personal-stat response messages
- User-not-found messages
- Permission-denied messages
- Minimum permission level for looking up another user

See [`docs/CONFIGURATION.md`](docs/CONFIGURATION.md) for the available settings and examples.

---

## 🔄 How It Works

### ✅ Viewer Redeems First

1. A viewer redeems the configured First reward.
2. Their lifetime First count is increased.
3. Their username is recorded under the current date in the history file.
4. Duplicate same-user entries for the same date are prevented.

### 📊 Viewer Requests the Leaderboard

1. The extension reads the saved leaderboard.
2. Users are ranked by their total First count.
3. The requested page is formatted and sent to chat.

### 👤 Viewer Uses `!firstme`

1. The extension checks whether a username was provided.
2. Without a username, it displays the requester’s stats.
3. With a username, it checks whether the requester has lookup permission.
4. It returns that viewer’s total wins and available history information.

---

## 📁 Files Created

The extension automatically creates its data files beneath the Streamer.bot installation directory:

```text
Omanges Extensions/
└── First/
    ├── FirstLeaderboard.json
    └── FirstHistory.json
```

### `FirstLeaderboard.json`

Stores each viewer and their total number of First wins.

### `FirstHistory.json`

Stores the First winner associated with each stream date.

> Back up the entire `Omanges Extensions/First` folder before moving Streamer.bot, reinstalling it, or replacing your computer.

---

## 🧹 Maintenance and Updating

When installing a newer version:

1. Back up `Omanges Extensions/First`.
2. Import the updated `.sb` file.
3. Review any duplicated actions or commands before enabling them.
4. Confirm that your reward assignments and permission settings remain correct.
5. Do not overwrite or delete your existing JSON files unless you intentionally want to reset the leaderboard.

---

## 🛠️ Troubleshooting

### The leaderboard is empty

Confirm that the First redemption action has run successfully and that `FirstLeaderboard.json` exists in the expected folder.

### `!firstme @username` shows the requester instead

Confirm that you are using the current extension version and that the lookup action receives the command input correctly.

### A viewer cannot look up another user

Review the lookup-permission argument inside the `!firstme` action. Personal lookups and other-user lookups can have different permission requirements.

### The JSON files are not being created

Make sure Streamer.bot has permission to write inside its installation directory and check the Streamer.bot logs for errors.

---

## 💡 Example Data

### Example Leaderboard

```json
{
  "omanges": {
    "count": 7
  },
  "digitalowen": {
    "count": 3
  }
}
```

### Example History

```json
{
  "2026-07-21": [
    "omanges"
  ],
  "2026-07-22": [
    "digitalowen"
  ]
}
```

---

## 📞 Support and Feedback

- Open a bug report or feature request through this repository’s GitHub Issues.
- Join the [SIDOR Community Discord](https://discord.gg/2pcKpMrxdD) for help or discussion.

This extension is designed to remain portable, customizable, and easy to manage inside Streamer.bot.

---

## 👤 Author

**Omanges**  
🟣 [Twitch.tv/Omanges](https://twitch.tv/omanges)  
💬 [SIDOR Community Discord](https://discord.gg/2pcKpMrxdD)

---

## 📄 License

Released under the [MIT License](LICENSE).

You are free to use, modify, and share this extension while retaining appropriate credit.
