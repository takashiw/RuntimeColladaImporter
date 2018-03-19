# RuntimeColladaImporter
Imports Blender files into Unity during Runtime. 
Made for DAUGs 🐶

## Using the BlenderRigController
The BlenderRigController uses on fileName in order to locate and load the `.blend` file. With this fileName, it will pull it in as a GameObject. If the `.blend` file is in the same directory as the texture `.tga` files, Unity property places them on the model. Only thing that doesn't get mapped is animations.

### Animations from Blender
The script takes all the animations and re-assigns them for what the model contains. The default animations are set for the Machop character, and will not work for any other monster.
These animations are reassigned in the `AnimationController`, which contains the followin states:
- standing (default entry)
- attack_1
- hit
- faint
- intro

Each state has a corresponding trigger which can be called in order to invoke the animation or the method `playAnimation(string triggerName)` can also be used. Simply call the trigger, and the animation will happen.
