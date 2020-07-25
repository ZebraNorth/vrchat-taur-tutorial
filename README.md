# How to Make a Taur Avatar in VRChat

## About Me

This tutorial was created by Zebra North, find me here:

1. [Twitter](https://twitter.com/ZebraNorth)
2. [FurAffinity](https://www.furaffinity.net/user/mrzebra/)
3. [mrzebra.co.uk](https://mrzebra.co.uk)

Questions and suggestions are welcome!

Good luck with your avataur!  /)*(\

## Notes & Thanks
1. Thanks to [@Voxian](https://twitter.com/Voxian) for the inspiration of the basic method.
2. Thanks to [@jessie_pup](https://twitter.com/jessie_pup) and RoBorg for assistance in Blender and Unity.
3. Making a taur with this method requires the Unity plugin "Final IK", which costs around £100.  You can do it for free by creating a walk cycle animation for the hind legs instead of using IK, but this tutorial does not cover that method.
4. Some instructions for Blender are given, but this is not a Blender tutorial.
5. These instructions are correct as of July 2020.

## Installation & Setup of Blender
1. Download the latest version of Blender from https://blender.org
2. Run the .msi file.
3. Launch Blender.
4. Download the CATS Blender plugin from https://github.com/michaeldegroot/cats-blender-plugin/archive/master.zip
5. In Blender, select Edit -> Preferences -> Add-ons
6. Click "Install" and select the cats-blender-plugin-master.zip file.
7. Check the checkbox next to "3D View: Cats blender plugin" to enable it.

## Installation & Setup of Unity

1. Download Unity Hub from https://unity3d.com/get-unity/download
2. Install and run Unity Hub.
3. Click on "Installs", "Add".
4. Click on "download archive".
5. Download version 2018.4.20f1.
6. Click on "Projects", "New", "Create" to create a new project	.  Use the "3D" project type.
7. Unity will now launch.
8. Select Window -> Asset Store.
9. Search for "Final IK".
10. Click "Download", then "Import".
11. Click "Import" on the popup window.
12. Optional, if you want bendy bones / jiggle bones.  This costs around £15.
    1. Search the Unity Store for "Dynamic Bone".
    2. Download and import Dynamic Bone.
13. Download the VRChat SDK version 2 (not 3) from https://vrchat.com/home/download
14. Click on Edit -> Import Package -> Custom Package and select the .unitypackage file you ust downloaded.

## Blender Model

1. Create your mesh as normal, and as a single object.  Remember to keep the poly count low and model it in the T-pose!
2. Create the armature in Object mode using Add -> Armature -> Single Bone.  Rig the front legs and the other body starting with the Hip bone pointing straight up, and use the bone names given in https://docs.unity3d.com/Manual/class-Avatar.html
3. Rig the rear legs using the same number of bones as the front legs.
4. Create a "Rear Hips" bone that the rear legs are parented to.
5. Create bones "Spine 1" to "Spine 5" to connect "Hips" to "Rear Hips".
6. Create bones for the tail, parented to "Rear Hips".
7. Add an "Armature" modifier to the mesh and select the armature.
8. Paint the weights.
   1. From Object mode, select the Armature first, then the model second.
   2. Switch to Weight Paint mode.
   3.  Press 'a' to select all bones.
   4. Select Weights -> Assign Automatic from Bones.
   5. Use the weight paint brush to adjust as necessary.
9. Create visemes by creating shape keys called "AA", "OH" and "CH" on the "Vertex Groups" panel for the mesh.
10. Select the CATS plugin from the tabs on the right of the main 3D view.  Fill in the visemes and press the "Create Visemes" button.  This will automatically generate new vertex groups.  Remember to press this any time you change the AA, OH, or CH shape keys.
11. Create a separate blinking blend shape for each eye called "Left Blink" and "Right Blink"
12. Fill in the "Eye Tracking" panel in CATS and press "Create Eye Tracking".
13. Press "Export Model" in CATS and save the FBX file in the "Assets" directory of your Unity project.

## Unity Project

1. Click on the FBX file in the "Assets" panel, then click on "Model" in the Inspector panel.
2. Set "Blend Shape Normals" to "Import".
3. Click on "Rig" and change "Animation Type" to "Humanoid".
4. Press "Apply".
5. Press "Configure…"
6. Ensure that the bones are mapped correctly to the front half of the avatar.  The "Jaw" bone on the "Head" page should not be mapped, as this will prevent the visemes from working.
7. If you get warnings about the T-pose, you may have to click "Pose" -> "Enforce T-Pose"
8. Press "Done".
9. On the "Materials" tab press "Extract Materials" and choose the Assets directory.
10. Copy the texture image files from your disk into the Assets directory.
11. Click on the material in the Project panel, then click the Albedo circle and select your texture.
12. Drag the FBX from "Assets" into the "Hierarch" panel.  This should place your avatar into the scene.
13. Right-click on your avatar root and choose "Unpack Prefab".
14. Select your avatar and press "Add Component" and choose "VRC_Avatar Descriptor".  If you do not have this, go back to "Installation & Setup of Unity" and install the VRC SDK.
15. Press "Auto Detect" to configure the visemes.
16. Adjust the "View Position" to place the sphere where your headset display will be in relation to the head bone.  It doesn't matter if it's inside the avatar's head, if you have a long muzzle.
17. Optional: Select the "Armature", press "Add Component" and add the "Draw Bones" script.  This will need to be removed before uploading, but it may help you if you need to debug.
18. Right-click on your model's root object in the Hierarchy tab and select "Create Empty".  Call it "Rear Root" and move it to below the rear hips.
19. Copy the "Armature" and paste it as a child of the "Rear Root".  Rename it to "Rear Armature".  If you are using "Draw Bones", change the colour to green.
20. Drag "Hips" from "Rear Armature" so it is a child of "Rear Hips" on "Armature".  Set its Transform Position to (0, 0, 0).  Drag it back so it is a child of "Rear Armature". You should now have two taur skeletons, with the front of one in the same place as the rear of the other.
21. Delete unneeded bones from the "Rear Armature": the entire rear half of the taur (anything after "Spine 1"), finger bones, front legs, and any bones past the "Head" bone (eyes, ears, etc).
22. Select the "Rear Hips" bone in the front armature and press "Add Component", and select "VRC_IK Follower"
23. Right click the "Rear Hips" and choose "Create Empty" twice to create two new transforms named "Rear Hips IK Follow Target" and "Rear Head IK Follow Target".
24. Move the "Rear Head IK Follow Target" vertically up to eye level, and slightly forwards.
25. Rotate the "Rear Head IK Follow Target" so that the blue arrow is pointing forward and the green arrow is pointing up.
26. Rotate the "Rear Hips IK Follow Target" so that the blue arrow is pointing down and the green arrow is pointing forward.
27. Select the "Rear Root", press "Add Component" and select "VR IK". (This is part of the Final IK package.)
28. Expand the "References" panel and fill in the boxes using bones under the "Rear Armature" for the upper body, and the front armature for the lower body.
    1. Root: "Rear Root"
    2. Pelvis: "Rear Root" -> "Rear Hips"
    3. Spine to Head: "Rear Root" -> "Spine" to "Head"
    4. Shoulder to Hand: "Rear Root" -> "Shoulder" to "Hand"
    5. Thigh to Toes: "Root" (NOT "Rear Root"!) -> "Thigh" to "Toes".  (Note that toes are optional, you can stop at Foot).
29. Expand the "Solver" and "Spine" panel.  Set the "Head Target" to "Rear Head IK Follow Target" and the "Pelvis Target" to "Rear Hips IK Follow Target".
30. Set the "Position Weight", "Rotation Weight", "Pelvis Position Weight" and "Pelvis Rotation Weight" to 1 under the "Spine".  Set all other "Position Weight" and "Rotation Weight"s to 0.
31. Optional: Uncheck "Plant Feet".  Your avatar can move faster than the IK solver can keep up with.  If "Plant Feet" is checked then your body will get stretched out until the rear legs catch up.  If it is unchecked then the rear legs will lift off the ground slightly when they can't keep up.
32. Set "Palm To Thumb Axis" to (-1, 0, 0) for "Left Arm" and "Right Arm".
33. Drag "Left Leg" and "Right Leg" from "Root" -> "Rear Hips" to "Rear Root" -> "Hips".
34. Select your avatar root and press the Play button.  Dragging the avatar backwards and forwards should make the hind legs walk. The front legs will not animate, this is normal because it is handled by VR Chat.  If it does not work properly, go back through this list and double-check each item.  Be sure to exit play mode before making any further changes.
35. Adjust the Step Height, Heel Height, Foot Distance, and the position of the Rear Head IK Follower until it looks right.
36. Select the avatar root in the hierarchy, click "Add Component" and select "Dynamic Bone".  For the Root select "Spine 1".  Set "Exclusions" size to 1 and add "Rear Hips".  You may also need the tail if it is parented from "Spine 5".  Adjust the parameters as required.
37. Upload the model by selecting "VRChat SDK" from the main menu, then "Show Control Panel".
38. Press "Auto Fix" to remove the DrawBones script if enabled, and to enable streaming mipmaps.
39. Press "Build and Publish for Windows".
40. Fill in the details and press "Upload".

## Making it Rideable

If you want other players to be able to ride you, you can follow these steps.  This will make an invisible sit target,
however you can easily add your own saddle mesh if you want.

1. Select the "Spine 3" bone, right-click, and choose "Create Empty", call it "Saddle Container".
2. Right-click on "Saddle Container" and choose "Create Empty", call it "Saddle IK Follower".
3. Select "Saddle IK Follower", press "Add Component" and select "VRC_IK Follower".
4. Right-click on "Saddle IK Follower" and choose "3D Object" -> "Capsule", call it "Saddle Collider".
5. Right click the "Saddle Collider" and choose "Create Empty" twice, call them "Sit Target" and "Dismount Target".
6. Select "Saddle Collider", press "Add Component" and select "VRC_Station".
7. Uncheck "Can Use Station From Station".
8. Select "Sit Target" as the "Player Enter Location".
9. Select "Dismount Target" as the "Player Exit Location"
10. Rotate the "Sit Target" and "Dismount Target" by 90 degrees around the X axis so the blue arrow is forward and the green arrow is up.
11. Move the "Sit Target" somewhere under the saddle.  You will have to experiment to find the exact location, and it will vary depending on the rider's height.
12. Move the "Dismount Target" onto the ground next to your avatar.
13. Delete the capsule mesh renderer and mesh filter by clicking the gear at the top-right and choosing "Remove Component".

## Eject Riders

If you have a sadde then it's probably wise to have the ability to force unwanted riders to dismount.

1. Duplicate the entire avatar.
2. Create a new "Animation Controller" and assign it to the duplicate avatar's "Animator" component.
3. With your avatar selected, select "Window" -> "Animation" -> "Animation" to show the animation tab.
4. Press "Create" to make a new animation.
5. Search in the "Project" window for "idle", and select "IDLE" (all caps, under VR Chat Examples/Examples2/Animation/Male Standing Pose.fbx)
6. Click in the dope sheet (the window with all the diamonds in the "Animation" tab) and press Ctrl+A to select them all, then Ctrl+C to copy.
7. Go back to the "Heirarchy" panel and select your duplicate avatar, then back to the "Animation" tab and paste into the dope sheet.
8. Scroll to the bottom of the "Animation" tab and press "Add Property", then select "Armature" -> "Hips" -> "Saddle Collider" -> "IsActive", and press the "+" button on the right.
9. Scrub the timeline in between the two keyframes, and uncheck the "IsActive" box.
10. Search the "Hierarchy" panel for "CustomOverrideEmpty" and duplicate it.
11. Select your main avatar (not the duplicate), click the circle next to "Custom Standing Anims", and select your CustomOverrideEmpty.
12. Double-click on your CustomOverrideEmpty and click the circle next to "EMOTE1", then select your dismount animation.
