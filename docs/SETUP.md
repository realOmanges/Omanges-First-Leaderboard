# Setup

## Import

Import the `.sb` file from the `releases` folder into Streamer.bot. The export contains the First Redeem, First Reset, First Leaderboard, and First Me actions plus the associated chat commands.

## Channel-point reward

Create a Twitch reward for First, then select its reward ID in the reward-related sub-actions under **First Redeem** and **First Reset**. The exported reward ID belongs to the original installation and should not be assumed to match another channel.

## Commands and permissions

The imported commands are disabled by default. Review their permissions and then enable them.

- `!firstleaderboard`: leaderboard pages.
- `!firstme`: personal lookup and optional lookup of other users.

The First Me action contains settings controlling which roles can look up another user. Keep self-lookup broadly available while restricting other-user lookup as desired.

## Files

Data is saved under `Omanges Extensions/First` in Streamer.bot's base directory. Preserve `FirstLeaderboard.json` and `FirstHistory.json` when updating.
