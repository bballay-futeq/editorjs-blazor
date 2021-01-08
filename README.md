
# EditorJS Blazor

EditorJS.Blazor is a wrapper of EditorJS. 

## Setup
To add the library to your project, first either reference the project or add nuget package, then add following to your **_Host.cshtml**:

    <script src="_content/EditorJsBlazor/editor-js-blazor.js"></script>
 
 before 

    <script  src="_framework/blazor.server.js"></script>

## Building the library
To build the library, run **build.ps1** script. This script installs the npm packages and builds client scripts. If you're using Task Runner Explorer with Webpack extension, the scripts will run when you build the solution from VS. 

## Running the demo

To run the demo simply run **run.ps1** script.
