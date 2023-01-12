# UnityMVC

Small MVC variation demo created for a technical test from a Car manufacturer company.


## Details:

Code will be found at Assets/Scripts.
There is no Resources folder due to the fact that all images had copyright.

## Code details:

<div style="text-align: justify">

We have divided the structure of the code into 4 main modules which are:

- Controllers
- Data
- Injector
- Views

The main architecture resembles an MVC but with some variation, in this case we dispense the Model as we do not have that kind of data.<br> 
What can be most similar to the model would be the Data folder where we have used a [scriptable object](https://docs.unity3d.com/Manual/class-ScriptableObject.html) 
to create the fixed data which we are interested in having grouped: rotation speed of the hands, maximum and minimum rotation of the needles etc.

As for the view, this will be a Monobehaviour (PanelView) in charge of subscribing to a series of events created in the Controller and from these will receive the data to modify the graphic elements of the application. That is to say, the only responsibility that the view has will be to directly modify the values of the graphic elements.

As for controllers we have 2 to be precise:
- UserInput: in charge of receiving the input and transferring to the controller of the graphic panel if the user is pressing the designated key.
- PanelController: computes the UserInput data in order to know the values that correspond to the element from the View.

PanelController is a dependency from UserInput, but as you can see, an external class (MainInjector) has been used as a dependency injector and thus remove UserInput from the responsibility of creating the PanelController instance.

</div>

