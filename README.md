# Music Manager (DBSProject)

## About
This app can play any `.wma` or `.mp3` file on a Windows system. It automatically figures out the default music folder location and loads all files into an `MMHHistory.mmh` file for faster access.

The most interesting feature of this app is its unique probability-based shuffle algorithm. Songs are never randomly shuffled, instead, they're ordered such that your most heard songs are played first. Most music players use a pseudo-random algorithm to pre-populate the playlist. However, in this app, you'll get to liste to songs that you normally listen to the most.

## How does it work?
Each song's probability increases in two cases:
  1. You manually select that song from the list and play it
  2. You listen to more than 75% of the song (we usually skip the song as it nears the end)

This dynamic shuffling algorithm takes each song's cumulative probabilites into account and populates the shuffled playlist accordingly.

## Other Features
  * You can set volumes for individual speakers on your system (left/right). Moreover, you can even set the bass and treble to match your taste.
  * You can customize the default filename format, which will be reflected in the UI (14 options)
  * Apart from the unique shuffling algorithm, the app takes your genre, album and artist priorities into account (can be changed in settings)
  * Obviously, shuffle, mute, and repeat options are available.

## Shortcuts
  * Play/Pause:  Ctrl + P
  * Next:        Ctrl + →
  * Previous:    Ctrl + ←
  * Stop:        Ctrl + S
