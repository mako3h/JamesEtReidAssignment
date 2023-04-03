# JamesEtReidAssignment

Integrations: <br>
<br>
Normal Mapping/Texturing: <br>
Normal Maps contain info about the normal at that UV coordinate, normals are then used by the fragment shader. We use colour, main texture, bump texture and bump slider properties. Uses the lambert lighting model. We input our main texture and normal map texture. Our albedo is equal to our main texture multiplied by our colour property. Normal is unpacked, converting the rgb values of the normal map to xyz coordinates, and is then multiplied by the slider value. <br>
<br>
As for our implementations, we utilized normal mapping in many aspects of our game. For example, the beach theme is created through the use of sand and water textures. Pairing this with the other textures applied to other gameobjects, the scene becomes much more unique and visually appealing. <br>
<br>

<br>
Colour Grading: <br>
Alters and enhances the colour of an image by changing the colour of a pixel to another colour. Done through the use of LUTs/Lookup Tables. Our properties include a main texture, LUT texture and Contribution Range or, the intensity of the grade. We then ensure there is no culling or depth so that we can see the effects taking place, and we create a vertex and fragment shader. In our appdata, we have our position, aswell as uv coordinates. In our v2f function, we have the same; position and uv coordinates. Our vertex shader transforms our object from object space to clip space. In our fragment shader, our colour is saturated (0<value<1), we add precision to our sampling so we cannot go beyond the limits of the LUT and we calculate the offset to map the image to the LUT. <br>
<br>
In terms of the applications of our own implemented colour grades, we designed our LUTs to represent two settings to fit the beach theme of our game. The first, the cool LUT, is to represent a colder nighttime atmosphere. The second, the warm LUT, is to represent a bright and sunny daytime summer atmosphere. <br>
<br>
Toon Shading: <br>
Toon shading, or cel shading, is a type of rendering design to make 3D graphics appear flat, this is done by using less shading colour, instead of a gradient. Instead of a gradual linear transition, toon shading switches colours at the extremes. Requires an image of bands, with separate shading levels, the toon ramp. In our cel shading shader, we use the ToonRamp lighting model, to help apply the toon effect. We then have our LightingToonRamp function to calculate the toonshading itself. We perform calculations such as dotting the normal and light direction to acquire our diff value. We then add our Ramp Texture with our diff value to set our ramp value. Lastly we multiply our albedo by the colour of our light by our ramp value. We then return c, our toon shading value. Lastly in our surf function, we add a colour property to our albedo. <br>
<br>
Water: <br>
For our scene, we utilized a water wave shader to help create a beach theme for our game. We did so by building upon the inital shader from the lectures, while also adding bump mapping and scrolling overlay/foam. This way, we can create more realistic water effects. <br>
<br>
We create this water wave effect by creating a sine wave motion in our shader. To do so we perform a group of calculations. Firstly, we calculate a variable, t, which is equal to the unity time variable multiplied by a speed property. We then calculate the height of our wave. This is done by using the sine math function, and calculating the sine of t + x coordinate value + frequency property. This is then multiplied by an amplitude property. We then add another sine calculation; the sine of t times 2 + x coordinate value + frequency property squared. This sine calculation is also multiplied by the amplitude. With these two sine functions added together, we have our wave height. Practically, this will push the vertices of our plane (water) in the directions of the x-axis. We then set our y coordinate value to the y coordinate value plus our wave height. This sets the y vertex value to the current value. We then updated the normals by normalizing the x, y, and z normals while adding wave height to the x. Lastly, we update the colour to match our wave height. This ensures that the peaks of the wave are brighter, whereas the bottoms are darker, creating a more realistic wave look.<br>
<br>
To add the scrolling/foam effect, we simply add a newuv value in our surf function. In this, we add our foam texture with a scrollX and scrollY property (range), which control the direction of the scroll. To ensure that the foam updates, we set both scroll properties to be multiplied by the unity time variable. <br>
<br>
<br>
