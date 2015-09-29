﻿// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"

open System.IO
open Fake

RestorePackages()


let sln = "CsharpSixDemo.sln"

Target "Help" PrintTargets

Target "Build" (fun _ ->
  let buildMode = getBuildParamOrDefault "buildMode" "Release"
  let config defaults = {defaults with Properties = ["Configuration", buildMode]}
  build config sln
)


RunTargetOrDefault "Build"