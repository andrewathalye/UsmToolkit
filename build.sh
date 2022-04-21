#!/bin/sh
dotnet publish --configuration Release --framework netcoreapp6.0 --output publish /p:DebugType=None /p:DebugSymbols=false
