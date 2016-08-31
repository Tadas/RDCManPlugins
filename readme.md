# Plugins for Remote Desktop Connection Manager #

Remote Desktop Connection Manager 2.7 (maybe earlier?) contains undocumented support for plugins. This is an attempt to document this functionality.

Plugins are C# dlls (.NET 4.0?) which export a class implementing IPlugin interface. Add `C:\Program Files (x86)\Microsoft\Remote Desktop Connection Manager\RDCMan.exe` to your project references.

## Plugin loading ##

For a plugin to be loaded the dll must be placed in the same folder as `RDCMan.exe` and it must be called `Plugin.*.dll`

## IPlugin interface ##

Plugins implement the `IPlugin` interface which has a couple of lifetime events. 
- OnContextMenu - called when the user right clicks a server node in the tree
- SaveSettings - called when the user clicks OK in the Options dialog


See Plugin.Sample for a working example. Place the compiled dll in the same folder as RDCMan.exe