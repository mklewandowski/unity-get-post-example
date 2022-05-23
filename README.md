# unity-get-post-example
An example project showing integration of HTTP GET and POST methods in Unity. This project allows the user to select a favorite color from a set of 4 colors. The user's answer is then sent using POST to a PHP script on a web server that processes the answer and adds it to a text file containing the cummulative answers located on the same web server. HTTP GET is then used to request the contents of the cummulative answers text file and show the results to the user. This project is created using Unity version 2021.3.0f.1.

## Running Locally
Use the following steps to run locally:
1. Clone this repo
2. Open repo folder using Unity 2021.3.0f.1
3. Install Text Mesh Pro
4. Upload `unity-get-post-example-process.php` and `unity-get-post-example-process.txt` located in the `WebServer` folder to a web server that you will use for testing.
5. In the `Upload` and `Download` functions located in `SceneManager.cs`, change the 2 instance of "www.MYSERVER.com" to the web server that you will use for testing.

## Development Tools
- Created using Unity 2021.3.0f.1
- Code edited using Visual Studio Code and Notepad++.
