<p align="center">
  <img width="70%" src="https://github.com/ashishgopalhattimare/PathMarkAR/blob/master/Extras/logo.png">
</p>

# PathMarkAR

An augmented reality indoor navigation app made using Google ARCore and Unity

*This was made at **NITK Surathkal** for **HackVerse** by team **Array[] yaar;***



## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.



### Prerequisites

Download or clone the repository onto your local machine.

Download the latest version of [Unity](http://www.unity.com/) from [here](https://unity3d.com/get-unity/download). Unity Hub is available to facilitate the management of Unity installations and projects. *(**Unity 2018.3.11f1** is recommended for this project)*



### Installing

Install Unity and open the project in Unity using Unity Hub on your system.

Cloning the project should include all the required libraries and plugins. However, if errors show up, the following can be done to manually get the application running. 

Install the ARCore SDK for Unity from [here](https://github.com/google-ar/arcore-unity-sdk/releases). The full guide can be found at [Quickstart for Android](https://developers.google.com/ar/develop/unity/quickstart-android) page at the Google Developers site.

Things should load up smoothly. Warnings may be ignored.

For Android and iOS support, Android Development and iOS Development plugins should be installed as well. iOS support was not extensively tested and might require some additional effort to get it running. ARKit plugin must also be installed if working on iOS.



## Deployment

Might need to install Android Studio with the Android SDK and JDK for exporting the app to an Android device.

For exporting an app to iOS, Xcode (11.3 or above) must be installed on a Mac running macOS 10.14 Mojave or later. An Apple Developer account is required for signing the application.

For a quick demo, an apk file has been attached as `pathmarkARX.apk` which can be installed on an Android device. The apk compatibility cannot be guaranteed.



## Motivation

Imagine going to a mall and getting lost in the maze of shops. If an augmented reality app could guide users to their destination using the shortest path, it could save users from a lot of hassle and save time.

This app can also be used when exploring unknown places or trekking so that a path can be traced back to the source.



### Applications


#### Malls & Airports
At the entrance, the user will be shown a list of all the shops. Once a destination is selected, a stored AR path is shown.
This service can be made available to a selected number of shops who are paid members.
A subscription model can be implemented for businesses if they wish to stay on the app.

#### Promoted Businesses
Businesses who would like to be promoted can have their places suggested when the app is being used for navigation. This will need to be as unintrusive as possible.

#### Integration with Maps
Once the destination is close enough, Google Maps does not provide the best user experience. In that case an indoor AR application seems more suited to the cause.



## Demos

<p align="center">
  <img src="https://github.com/ashishgopalhattimare/PathMarkAR/blob/master/Extras/plane-detect-marker-place.gif" width="40%">
</p>
<p align="center">
  <i>Demo of the plane detection and placing markers on the screen (2.5x speed)</i>
</p>

<p align="center">
<img src="https://github.com/ashishgopalhattimare/PathMarkAR/blob/master/Extras/place-marker-rabbit.gif" width="40%"> <img src="https://github.com/ashishgopalhattimare/PathMarkAR/blob/master/Extras/rabbit-running.gif" width="40%"> 
</p>
<p align="center">
  <i>Placing markers ➡ Saving markers ➡ Character guiding user</i>
</p>


## Status of the Project

#### What Works
- Detection of real world planes using ARCore
- Placement of markers that will be used to mark the path to be used
- Storing of paths to be used at a later time
- Guiding the user along the saved path using a character model

####  Future Work
The project can be scaled up so that more paths can be saved. Currently only 2 paths are being saved and are being switched between using the on screen buttons.

Once multiple paths are stored, they can be integrated into a search like interface so that the user can choose which destination is to be reached.

Other user interface and user experience improvements can be implemented to make the app easier and more pleasing to use.



## Built With

* [Unity](http://www.unity.com/) - Cross-platform real-time game engine developed by Unity Technologies
* [ARCore](https://developers.google.com/ar) - A software development kit developed by Google that allows for augmented reality applications to be built
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/) - Integrated development environment for C# from Microsoft
* [Visual Studio Code](https://code.visualstudio.com) - An open source code editor developed by Microsoft 



## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.



## Versioning

We used [GitHub](http://www.github.com/) for versioning. For the versions available, see the [tags on this repository](https://github.com/ashishgopalhattimare/PathMarkAR/tags). 



## Authors

* **Ashish Gopal Hattimare** - *Lead Developer* - [ashishgopalhattimare](https://github.com/ashishgopalhattimare)
* **Rajat Dipta Biswas** - *Developer and Designer* - [rajatdiptabiswas](https://github.com/rajatdiptabiswas)
* **Akash Yadav** - *Tester and Technical Lead* - [aky91](https://github.com/aky91)

See also the list of [contributors](https://github.com/ashishgopalhattimare/PathMarkAR/contributors) who participated in this project.



## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details



## Acknowledgments

* raywenderlich.com | [Unity for Beginners](https://www.raywenderlich.com/unity/learn)
* andreasjakl.com | [Getting Started with Google ARCore, Part 2: Visualizing Planes & Placing Objects](https://www.andreasjakl.com/getting-started-with-google-arcore-part-2-visualizing-planes-placing-objects/)
* Google Developers | [Quickstart for Android](https://developers.google.com/ar/develop/unity/quickstart-android)
* Google Developers | [Unity API Reference for ARCore](https://developers.google.com/ar/reference/unity/)
* Unity Asset Store | [White Rabbit by Niwashi Games](https://assetstore.unity.com/packages/3d/characters/animals/white-rabbit-138709)
* Unity Asset Store | [Vectrosity by Starscene Software](https://assetstore.unity.com/packages/tools/particles-effects/vectrosity-82)
* [Unity3D Documentations](https://docs.unity3d.com/Manual/index.html)
* [Unity Answers](https://answers.unity.com/index.html)
* [StackOverflow](https://stackoverflow.com)
