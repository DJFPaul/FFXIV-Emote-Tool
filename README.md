# FFXIV Emote Tool

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/7afb0d0c-50e6-4cdb-a892-234e6b3355bb)


This utility provides an easy option to add the doze / sit emote to your hotbar, without Cheat Engine or Mods / Launchers. <br>
This is done by hex editing the HOTBAR.DAT config file, changing the last 2 slots of the shared hotbar 8 to the respective emotes. <br>
This does not break any other hotbar slots and can be used on an already configured hotbar. <br>
(It does override the last 2 slots on Hotbar 8, anything already there will be replaced.) <br>
<br>
It is highly recommendet to create a manual backup of your char configs, before using this utility. <br>
`C:\Users\%username%\Documents\My Games\FINAL FANTASY XIV - A Realm Reborn` <br>

<br>
Usage of this utility is at your own risk.<br>
<br>

# Preparation
Download and extract the latest version of this utility from Releases. <br>
https://github.com/DJFPaul/FFXIV-Emote-Tool/releases <br>
<br>

Before launching it, check / prepare your hotbar 8. <br>
<br>
To do this, log into the character you want to add the emotes to. <br>
Open the main menu, and pick "Character Configuration". <br>

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/53e1df59-2848-431b-849b-3354d0a30b04)
<br>
Now pick "Hotbar Settings", switch to the "Sharing" tab at the top, and enable "Hotbar 8", if not already enabled. <br>

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/b5020429-0e0f-46a8-a5c0-2f2cb5deb309)
<br>
Next, you can log out of the character. <br>

# Using the tool.
Launch the FFXIV Emote Tool. <br>
You will be greeted with a quick info screen. <br>

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/beb6f92b-4e22-4a4e-a13a-a3b3d4f814b9)
<br>
After confirming the dialogue, the main utility will open. <br>

You will now need to specify which HOTBAR.DAT to edit. <br>

## Manual process.
If you know your correct character folders already, just hit the OPEN button.

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/f58380c7-7f8b-4460-a67b-d942e49eb89e)
<br>
Shoul it not automatically send you to the config directory, you can normally find it at at the following path: <br>
 `C:\Users\%username%\Documents\My Games\FINAL FANTASY XIV - A Realm Reborn` <br>
<br>
Next you will need to pick the correct folder for the char you want to add the emotes too. <br>
The save location will contain folders with the following pattern <br>

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/4aca036e-0076-4e7f-8e65-ae7b1db60c3f)
<br>
## Automatic Process
If you do not know which one is the correct one, you can use the CharFinder feature of the tool. <br>
This feature helps you locate the correct HOTBAR.DAT automatically, by monitoring for file changes. <br>
(This is done without injecting or modding anything to the game, it watches for file changes.) <br>
<br>
Click the CharFinder button to launch the assistant utility.<br>
![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/c7c6bd58-3dd8-40d3-abd3-919d26c10287)

<br>
Once you can see this window, CharFinder is monitoring for changes. <br>

![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/6f76ef0e-4e84-465b-b5e2-941b07cf3357)
<br>
Login to the character you want to apply the patch too. <br>
Now drag around any Item/Spell/Action on any hotbar, it does not matter which. <br>
<br>
Once CharFinder detected a change, it will pop up a message like this. <br>
![image](https://github.com/DJFPaul/FFXIV-Emote-Tool/assets/35642602/7fbe5152-db25-47a6-9cc4-12bf6095b42f)
<br>
Hit "Yes" to load this characters HOTBAR.DAT into the Emote Tool. <br>
Now log out of the character again. <br>

## Patching
Once a HOTBAR.DAT has been specified, the patch button will enable it self. <br>
<br>
Hit PATCH and after confirming another short warning message, the utility will edit the hotbar file. <br>
When this process completed without error, you can now login to your char, and take a look at your Hotbar 8. <br>
This now should have the 2 hiden emotes on it. <br>
<br>
You may need to enable hotbar 8 in your HUD Layout first. <br>
The emotes can be dragged to any other hotbar slot. <br>
<br>

## Restore from Backup
If there is any error with your hotbar, you can restore from the automatic backup that was created. <br>
Navigate to your character folder and find the timestamped backup there. <br>
<br>
# Disclaimer
I'd like to remind that this is editing the game config in unintended ways. <br>
Usage of this utility is at your own risk. <br>
It is probably wise to not use these emotes in any crowded area. <br>
