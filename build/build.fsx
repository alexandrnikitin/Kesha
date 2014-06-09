// include Fake lib
#r @"../packages/FAKE.2.17.9/tools/FakeLib.dll"
open Fake

// Properties
let buildDir = "./output/"
let testDir  = "./test/"

let xUnitRunnerPath = "../packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir]
)

Target "Build" (fun _ ->
    !! "../src/Kesha/*.csproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
    !! "../src/Kesha.Tests/*.csproj"
      |> MSBuildDebug testDir "Build"
      |> Log "TestBuild-Output: "
)

Target "RunTests" (fun _ ->  
    !! (testDir + "/*.Tests.dll")
        |> xUnit (fun p -> 
            {p with 
                ToolPath = xUnitRunnerPath;
                ShadowCopy = false;
                HtmlOutput = true;
                XmlOutput = true;
                OutputDir = testDir })
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"Clean"
  ==> "Build"
  ==> "BuildTest"
  ==> "RunTests"
  ==> "Default"

// start build
RunTargetOrDefault "Default"