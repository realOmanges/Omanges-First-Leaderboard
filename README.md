# Omanges First With Leaderboard

A Streamer.bot extension that turns a Twitch **First** channel-point redemption into a persistent leaderboard and redemption history.

## Features

- Tracks how many times each viewer redeems First.
- Stores a date-based First history.
- Paginated `!firstleaderboard` command.
- `!firstme` lookup for the requester or another user.
- Configurable command messages and permission levels inside Streamer.bot.
- Automatically resets the First reward presentation for the next stream.

## Requirements

- Streamer.bot 1.0.0-alpha.1 or newer.
- Twitch account connected to Streamer.bot.
- A Twitch channel-point reward assigned to the **First Redeem** and **First Reset** actions.

## Installation

1. Download the `.sb` file from [`releases`](releases/).
2. In Streamer.bot, open **Import**.
3. Drag the `.sb` file into the import window and complete the import.
4. Create or select your First channel-point reward.
5. Assign that reward to the imported First actions where indicated.
6. Enable the imported commands after reviewing their permissions.

Detailed setup is available in [docs/SETUP.md](docs/SETUP.md).

## Commands

| Command | Description |
|---|---|
| `!firstleaderboard` | Displays page 1 of the leaderboard. |
| `!firstleaderboard 2` | Displays a requested leaderboard page. |
| `!firstleader` / `!firstleaders` | Aliases for the leaderboard command. |
| `!firstme` | Shows the requester's First statistics. |
| `!firstme @username` | Looks up another user's statistics when permitted. |

## Data files

The extension creates these files beneath the Streamer.bot installation directory:

```text
Omanges Extensions/
└── First/
    ├── FirstLeaderboard.json
    └── FirstHistory.json
```

Back up this folder before moving Streamer.bot or replacing your installation.

## Source

The C# inline-action source extracted from the Streamer.bot export is stored in [`src`](src/). The `.sb` file remains the installable release artifact.

## Version

Current release: **v1.0.0**

## License

Released under the MIT License.
