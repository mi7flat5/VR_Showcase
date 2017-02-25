# VR_Showcase

This project was done using Google Carboard SDK 1.2, You will need to download and import it to run this. That is the only dependency not present.
Currrently I'm using the Occulus MovieSample.cs script to run videos in textures, it currently does not function on iOS. 

I've muted the Android media player through a call into JNI from the MovieSample.cs, and am using a GvrAudioSource for spatial audio. You will need to comment calls to audioEmitter in the android build section of that script as well as commenting the call into JNI mediaplayer setVolume method.  


Most of my scripts are in the main Assets folder. Scripts for assets should be in their respective folders, and have liscense info at top, though I have added to or fixed bugs in almost all of them.

The first three areas have small puzzles. The origional idea was that you had to complete these puzzles to move into next area. Though the puzzles were very simple, I have removed the barriers so the user can freely move about, but the puzzles are still in the project.

The project is in the unimaginatively named main.unity scene.
<p>Check out the project page <a href="https://mi7flat5.github.io/VR_Showcase/">Here</a></p>
<div>
<img src="docs\\OverView.jpg.">
</div>
