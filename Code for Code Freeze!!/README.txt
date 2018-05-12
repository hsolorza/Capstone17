Our entire program is too big to upload onto GitHub, so these files and scripts are the support code that have to be added to a project in Unity in order to work properly. 

In order to quickly view what our code does, in the "Video Demostration" folder of this folder, video recordings have been added to demonstrate the functionalities of the provide code and our project overall.

ICREATE - GENERATIVE DESIGN IN VIRTUAL REALITY: REQUIREMENTS EXPLANATION

-------------------------------
External Interface Requirements [MET]
-------------------------------

User Interfaces: [MET]
The interface will functionally allow the user to spawn a 3D object, then modify it via a controller or gesture input. Additionally, the user will be able to save to a library for later use or load their creations to create complex structures. Finally, the application will display a way to transform the 3D objects by allowing the user to scale or resize the object.

Hardware Interfaces: [MET]
The VR application will be able to run on a HTC Vive VR headset and a computer that can run VR software. The minimum CPU and GPU requirements to successfully run the VR application are: Minimum CPU requirements: Intel Core i5-4590 or AMD FX 8350 (equivalent or better) Minimum GPU requirements: NVIDIA GTX 970 or AMD Radeon R9 290 (equivalent or better)

Software Interfaces: [MET]
The VR application will be usable on a Windows operating system capable of running the VR headsets respective proprietary software.

-----------------------
Functional Requirements [MET]
-----------------------

VR Environment: [MET]
The iCreate software will allow the user to move around in VR, instantiate a simple 3D object, and generate multiple instances of the 3D object.

Explanation How Met By Program:
- With the user’s movement with the headset and controllers, the user is able to move around in virtual reality with the HTC Vive, who can then spawn a 3D object and spawn multiple 3D objects within the scene if desired.

Object Library: [MET]
The iCreate software will allow the user to obtain 3D objects from the applications library.

Explanation How Met By Program:
- The user is able to select different types of 3D objects while using the program by selecting with a controller.

Curves: [MET]
The iCreate software will allow the user to draw a 3D curve, draw a trajectory in the form of a curve, create a B-Spline curve, a Bezier curve, a ellipse curve, a circle curve, a hyperbola curve, and a parabola curve.

Explanation How Met By Program:
- With the usage of mathematical equations and computational methods of program functions coded within the program, the creation of a curve (being either a b-spline, bezier, ellipse, circle, hyperbola, or parabola) is possible by the user by the click of a button within the program’s menus with the use of the user’s controllers, which can then be modi?ed by the user after such a creation.
- Further explanation comments in the code scripts itself, have been made explaining exactly how the code processes in the creation of the following curves: B-Spline, Bezier, Ellipse, Circle, Hyperbola, and Parabola.

Transformation and Translation: [MET]
The iCreate software will allow the user to extrude the object, resize the object, and indicate how they would like to rotate, translate, and scale objects across a curve.

Explanation How Met By Program:
- The user is able to extrude and resize an object with the use of the user’s controllers within the user’s scene, and then able to rotate, translate, and scale objects across a curve also with the user’s controllers.

Save and Load: [MET]
The iCreate software will allow the user to import geometry from a .fbx extension ?le format, import a 3D object, save a 3D object, save structures, and save the entirety of the project as a whole.

Explanation How Met By Program:
- The program is able to allow the user import a geometry from a .fbx extension ?le format with the use of the program’s menus, import a 3D object with the use of the user’s controllers, and save a 3D object, structures, and the entirety of the project as a whole when done properly by the use of the user’s controllers of selecting a button of the program’s menus.
- Further explanation comments in the code scripts itself, have been made explaining exactly how the code processes in the functionality of how the save and load functionalities are exactly done within the program.

------------------------
Performance Requirements [MET]
------------------------

The iCreate program should be able to run on a computer with at least an Intel Core i5-4590 or AMD FX 8350 (equivalent or better), a NVIDIA GTX 970 or AMD Radeon R9 290 (equivalent or better) graphics card, at least 4GB of RAM, at at least 30 frames per second. The requirements to run iCreate will also depend on the user and the scale or intricacy of the architectural structure that is designed as a larger, more complex structure will require more processing power and a stronger graphics card.

NOTE:
There are still bugs within the program itself overall. Program is not in a state of a 100% perfection, but requirements have been met in some form or another. Room for improvement of the program is present.