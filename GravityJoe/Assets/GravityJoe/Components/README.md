# Component
Create your component here. A component should be self-contained. We will avoid the flat/file-type-based project structure, and instead adopting the component-based structure.

# TL;DR

1. Use component to group/organize all the element related to a certain thing under the same folder. I.e, a `Dog` character has a spritesheet, barking SFX, sweat VFX particles, and its scripts. Put all of them under a `Dog` folder instead of spreading them out. 
1. Component allows feature branch merge less painful in Unity.
1. Component allows better task distriubtion and code ownership.

### What is NOT a component?
If it is standalone, e.g a single script that rotate any gameobject you attached it to, then it is not a component. Put them in the `Utility` directory. If the script requires the present of some stuff, you might want to make it a component. This practice followed Unity's Standard Assets package.

### If I have two NPCs that share the same script, are they two components?

That is a component with 2 `prefabs`.

# In-depth explanation

## Why Component?

Novice developer usually starts out with a flat project structure that looks like this:

```
/material
	|___/mat1
	|___/mat2
	|___/mat3
/prefabs
	|___/fab1
	|___/fab2
	|___/fab3
/scripts
	|___/behavior1
	|___/behavior2
	|___/behavior3
/textures
	|___/t1
	|___/t2
	|___/t3
/images
	|___/s1
	|___/x1
	|___/y1
```

In each directory, you would put files of the same type. This structure is problematic because it lacks focus. e.g, To find all the files related to a single character, you will have to look for them all over these folders. 

A better structure called `Component project` looks like this:

```
/Components/
	|--- MainCharacter/
	|         |___/main_character_texture.png
	|         |___/prefabs1
	|         |___/Player_behavior1.cs
	|         |___/player_animation1
	|         |___/test.scene
	|--- Settlement/
	|         |___/settlte_texture.png
	|         |___/prefab1
	|         |___/prefab2
	|         |___/test.scene
...
```

The idea is, for each component, we group all files related to the component, from texture to prefab to sprite, into a single directory, instead of distributing them into separate directory. You can further divide the MainCharacter directory to have type-based structure if you want. It makes the directory more organized, but take some extra step. For example:

```
/component/
	|--- MainCharacter/
	|         |___/Texture/
	|         |       |___/texture.png
	|         |___/Prefabs/
	|         |       |___/prefab1
	|         |___/Scenes/
	|		  |		  |___/TestMovement.scene
```

With component structure, we are encouraged to create branch per component, and merge them in as they are finalized. This structure has 3 benefits:
+ The component is self-contain. This means you can now carry the component directory into a different game/project and it will work out of the box.
+ Encourage branch creation and closing branch, and reduce merge conflict substantially. This also earn us "Agile" point.
+ More organized for large project.

You can actually see this practice in action when looking at Standard Assets package!

**NOTE**: For each component, there should be test scenes used to test out the component. The test scene is like a playground so that we can go back and revisit just the component instead of having to test it in the main scene. This will significantly improve troubleshooting and bug fixing. In production, these scene are run automatically using outside script runner, which automate the part of QA that can be automated. We probably don't have to do so in this particular project...