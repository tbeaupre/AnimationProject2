Tyler Beaupre
Project 2: Walk On The Wild Side!
https://youtu.be/ja9UlXCqCjI

This is a standard Unity project which when played, shows a cube with wings following a Catmull-Rom Spline while flapping its wings. As Splines are read in, their 
control points are drawn on the screen.

The winged creature which follows the spline is called 'CREATURE' and is made up of a number of links
One of the scripts attached to it, 'SplineTraveler.cs', handles file reading and the logic for starting and stopping spline traveling animations.
This script, along with all of the code pertaining to traveling along the spline, is in the folder called 'Spline'

The object which is responsible for drawing control points is called 'SplineObj'
The script 'SplineObj.cs' controls these objects. It initializes the mathematical Spline variable, draws the control points, and has some logic for calculating
 the traveler's position along the spline.

The file 'Spline.cs' has all of the background math for the spline. It contains the control point positions, rotations, and calculates the tangents at the control
 points.

The file 'Timer.cs' has a class which holds timing information for the animation.

The code pertaining to the hierarchical model is all in the 'Hierarchy' folder.

Link.cs has the basic link code. It is an abstract class with two subclasses: ChildLink and RootLink. Links handle the initialization and updating of nodes.

ChildLink.cs is a child of Link. Children have a joint associated with them, which adds the animation to the hierarchy.

RootLink.cs is derived from Link. It is for a special case: the root node of the hierarchy. This is the only node which can be moved during play.
The object, 'Link0' is a root node and has the SplineTraveler script attached to it.

Joint.cs has the basic joint code. It is assigned a JointAnim which tells it how to affect the node below it at any given time.

JointAnim.cs is an abstract class which tells a Joint how it's supposed to alter the rotation and position of the link.

WingAnim.cs is a type of JointAnim which flaps the wings. There are separate Wing Animation objects for the two wings of the creature because the rotations are reversed.