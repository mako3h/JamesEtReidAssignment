# JamesEtReidAssignment
Youtube Link: 
<br>
<br>
**The Game Explanation:**<br>
Within this game, the player plays throughout a sunny environment in a beach themed maze. There is a warm cozy feel, along with water surrounding the players as they can see it through the windows. It is a first person puzzle game where the player is looking to find a green cube within the maze. They must traverse throughout the maze in search for this cube which is the win condition for the player. <br>
**Integrations:** <br>
<br>
**Normal Mapping/Texturing:** <br>
Normal Maps contain info about the normal at that UV coordinate, normals are then used by the fragment shader. We use colour, main texture, bump texture and bump slider properties. Uses the lambert lighting model. We input our main texture and normal map texture. Our albedo is equal to our main texture multiplied by our colour property. Normal is unpacked, converting the rgb values of the normal map to xyz coordinates, and is then multiplied by the slider value. <br>
<br>
As for our implementations, we utilized normal mapping in many aspects of our game. For example, the beach theme is created through the use of sand and water textures. Pairing this with the other textures applied to other gameobjects, the scene becomes much more unique and visually appealing. <br>
<br>
**Part 3: Colour Grading** <br>
<br>
**Colour Grading:** <br>
Alters and enhances the colour of an image by changing the colour of a pixel to another colour. Done through the use of LUTs/Lookup Tables. Our properties include a main texture, LUT texture and Contribution Range or, the intensity of the grade. We then ensure there is no culling or depth so that we can see the effects taking place, and we create a vertex and fragment shader. In our appdata, we have our position, aswell as uv coordinates. In our v2f function, we have the same; position and uv coordinates. Our vertex shader transforms our object from object space to clip space. In our fragment shader, our colour is saturated (0 < value < 1), we add precision to our sampling so we cannot go beyond the limits of the LUT and we calculate the offset to map the image to the LUT. <br>
<br>
In terms of the applications of our own implemented colour grades, we designed our LUTs to represent two settings to fit the beach theme of our game. The first, the cool LUT, is to represent a colder nighttime atmosphere. The second, the warm LUT, is to represent a bright and sunny daytime summer atmosphere. <br>
<br>
**Part 4: Visual Effects** <br>
<br>
**Toon Shading:** <br>
Toon shading, or cel shading, is a type of rendering design to make 3D graphics appear flat, this is done by using less shading colour, instead of a gradient. Instead of a gradual linear transition, toon shading switches colours at the extremes. Requires an image of bands, with separate shading levels, the toon ramp. In our cel shading shader, we use the ToonRamp lighting model, to help apply the toon effect. We then have our LightingToonRamp function to calculate the toonshading itself. We perform calculations such as dotting the normal and light direction to acquire our diff value. We then add our Ramp Texture with our diff value to set our ramp value. Lastly we multiply our albedo by the colour of our light by our ramp value. We then return c, our toon shading value. Lastly in our surf function, we add a colour property to our albedo. <br>
<br>
We utilized toon shading to add more of a contrast between the environment and the goal object. This way, the goal has a unique touch to it, separating it from the rest of the scene. <br>
<br>
**Lens Flare:** <br>
<br>
Lens flare is a tool that allows us to enhance directional lighting. In other words, giving the player the indication that the lighting is very bright. In a real life camera, this occurs when light is scattered in response to a bright light source. This occurs through internal reflection stemming from material imperfections in the lens.
<br>
In unity, we can create a lensflare flare material and assign it to a light source, such as directional light. We can then apply a flare layer component onto our camera to create the lens flare effect into our scene. A lens flare was utilized in our scene to showcase that the light source (sun) was very bright, matching the sunny beach theme of the game. <br>
<br>
**Part 5: Additional Effects** <br>
<br>
**Outlining:** <br>
Outlining is essentially the process of adding a solid colour "outline" around the object. This can be a way to define, highlight, or add detail to a gameobject. In our scene, outlining was utilized to create a highlight effect around the goal object, making it stand out more, and make it more vibrant. Additionally, and as mentioned prior, toon shading and rim lighting were applied with the outline, to enhance the highlight effect. <br>
<br>
The initial outlining shader made in-class was used as a base to build off of. The outlining shader utilizes two passes to seperate the calculations. The first pass is where the outline colour is calculated and then applied, whereas the second is where the rest of the lighting effects are applied. The shadow shader uses the same 2 pass process, calculating the lighting initially, then finalizing the shadows in the second pass. 
<br>
In the first pass, we utilize the lambert lighting model with a vertex shader. We also turn OFF the z-buffer. The pass is very simple, as the only calculation in the vertex shader is adding the normal multiplied by the outline amount (range) to our xyz vertex values. In the surf function, we simply set the emission to our outline colour's rgb value. In the second pass, we use the toonramp lighting model to use toon shading. We then turn ON the z-buffer. We then perform toon shading calculations (see above). Lastly in our surf function, we perform normal mapping techniques (see above // however we did not add any textures to this object). We lastly set our rim value for rim lighting by dotting the normalized view direction with the normal, saturating it, and then subtracting it from one. We then set our emission to equal our rim colour property multiplied by our rim value to the power of the rimpower property. <br>
<br>
Too enhance the outline effect, we set the renderqueue option in the unity inspector to transparent. This helps make the outline appear around the object better. <br>
<br>
**Water:** <br>
For our scene, we utilized a water wave shader to help create a beach theme for our game. We did so by building upon the inital shader from the lectures, while also adding bump mapping and scrolling overlay/foam. This way, we can create more realistic water effects. <br>
<br>
We create this water wave effect by creating a sine wave motion in our shader. To do so we perform a group of calculations. Firstly, we calculate a variable, t, which is equal to the unity time variable multiplied by a speed property. We then calculate the height of our wave. This is done by using the sine math function, and calculating the sine of t + x coordinate value + frequency property. This is then multiplied by an amplitude property. We then add another sine calculation; the sine of t times 2 + x coordinate value + frequency property squared. This sine calculation is also multiplied by the amplitude. With these two sine functions added together, we have our wave height. Practically, this will push the vertices of our plane (water) in the directions of the x-axis. We then set our y coordinate value to the y coordinate value plus our wave height. This sets the y vertex value to the current value. We then updated the normals by normalizing the x, y, and z normals while adding wave height to the x. Lastly, we update the colour to match our wave height. This ensures that the peaks of the wave are brighter, whereas the bottoms are darker, creating a more realistic wave look.<br>
<br>
To add the scrolling/foam effect, we simply add a newuv value in our surf function. In this, we add our foam texture with a scrollX and scrollY property (range), which control the direction of the scroll. To ensure that the foam updates, we set both scroll properties to be multiplied by the unity time variable. <br>
<br>
The water was implemented around the surroundings of the scene. The player can see the water in action by looking our through the windows along the perimeter of the maze. This, again, adds to the beach theme of the game. <br>
<br>
**Shadow Lines:** <br>
This technique allows us to create a custom shadow effect, casting transparent lines with our shadows. This helps add more detail to our scene and making it more interesting.
<br>
This shader consists of 2 passes, one to seperate the shadow casting (Pass 2), and one for creating the shadow lines as well as handling other properties like textures. The shader utilizes a vertex and fragment shader in both passes. We then tell unity to ignore lightmaps, so that we can create our own shadows. In our appdata we have standard values such as position, normal, and uv coordinates. In our v2f, we have our uv coordinates, colour, position, and shadow coordinates. In our vertex shader we calculate our shadow. We do so by converting the normal to world space, then converting it to something the fragment shader can use. In our fragment shader, we use the SHADOW_ATTENUATION boolean value to whether an object will recieve the main object's shadows or not (if the lines appear on it or not). Our shadow colour is equal to our shadow texture, our shadow lines, multiplied by our linesZoom property, adjusting how far apart our lines are. We then assign our shadow, col, and shadow colour values into our finalColour value by lerping them together. We then return finalColour. In our second pass, we use shadowcaster, telling unity we are casting our own shadows. We then pass our shadowcaster values from our v2f to our vertex shade, and then through to our fragment shader.
<br>
This shadow effect was added to every wall in the scene, as well as the player object and the goal object. <br>
<br>
**Glass:**<br>
Glass allows us to create a transparent/see-through surface, creating a window effect. This can be useful in allowing light to travel into a room or to allow the player to see out in certain areas. <br>
<br>
This shader consists of one pass, containing a vertex and fragment shader. Prior to our pass we use GrabPass{} to grab the framebuffer contents into a texture to use in subsequent passes. This helps allow us to create the window/see-through effect by grabbing the screen behind the object (wall) and then using it as a texture, again creating the window effect. Our appdata consists of position and uv coordinates. In v2f, we again have uv coordinates, aswell as new unique uv values to ensure only a small portion of the scene can be seen through the window. We use uvgrab and uvbump to perform this. Additionally, we also need the size of the texel. In our vertex function, we take the vertices from the window and tranform them from world space to clip space, using UnityObjectToClipPos. We then calculate the position of the window within the screen space and the uv coordinates that correspond to it. This is done by setting the x and y coordinates of the uvgrab to equal the x and y uv coordinates multiplied by the scale property then added with the w coordinate. This is then all mulitplied by 0.5. We next set the uvgrab z and w values to equal the z and w uv coordinates. The uv is then set to the main texture, while the uvbump is set to the bump texture. In our fragment function, we first apply bump mapping by unpacking normals (see above). We create an offset value, setting it equal to the bump multiplied by the scale, which is then multiplied by the grabtexture texel size. Our uvgrab x and y values are then set equal the offset time the uvgrab z value plus the uvgrab x and y values. We create our colour value and set it equal to our grabtexture with a projected uvgrab value. We set our tint equal to our main texture. We then multiply colour by tint, creating the see-through effect by multiplying an existing colour with one from the main texture. We then return colour. <br>
<br>
Glass was implmented around the perimeter of the maze allowing us to see out to the water surroundings. The windows use a stained glass texture, to add a more unique visual experience, filling the scene with more vibrant colour. <br>
![CustomGlass](https://user-images.githubusercontent.com/122996304/229678426-0c399328-bf6d-4b32-ba2f-c448168861c7.png) 
<br>
**Part 6: Additional Post Processing Effects** <br>
<br>
**Bloom:** <br>
Bloom is the process of blurring an image, combining it with the original image, and then brightening it. <br>
<br>
The bloom shader utilizes 5 passes, as there are a large number of calculations to apply the burring and then the brightening of the image. Prior to the passes, we turn off culling and the z-buffer. We also utilize vertexData and Interpolator structs paired with interpolator vertexProgram to transform vertex positions to clip space and pass through the texture coordinates. <br>
<br>
We then create a single pass vertex fragment shader. In the fragment shader, we sample the source texture, and it as the result. We then make it a colour of our choosing; for example, red -> half4(1, 0, 0, 0). <br>
<br>
We then create a bloom c# script to pair with our shader. This is where we perform many of the burring operations, including up and downsampling. In the script, we add a public field to attach our shader to the script, a range for the number of blur iterations, and an array to process the blurring. Next is the OnRenderImage function, a method that occurs after the camera renders. The first for loop is where we apply bilinear filtering. We divide the width and height of the image by 2 for every iteration. <br>
<br>
**Depth of Field:** <br>
<br>
