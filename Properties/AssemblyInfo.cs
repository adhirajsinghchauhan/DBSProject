using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Genreal Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Music Manager")]
[assembly: AssemblyDescription("This software will manage all the operations of a Music Manager/Library. The main aim of this project is development of a software which provides an easy access to play music files on your PC, along with editing capabilities like cutting, cropping, volume levelling etc. The media files will be sorted and categorised according to Artist, Title, Genre and Album.\n\nFollowing are a few important features of this project:\n•Files can be searched and indexed into a .mmh file\n•File metadata can be edited\n•Performance-optimised shuffling, sorting and looping algorithms\n•Playlists can be created using queue data structure\n•Song lyrics and other discography metadata would be fetched from a third-party service online\n\nThe UI will give the user various filename formats to save a particular file. Also, Windows Media Player playlists (*.wpl) can be added to this application. This project will use a probability-based shuffling algorithm (Morkov Chain), in which the priority of a particular song is taken into account. The priority of the song increases in two cases: 1. The user selects a song and plays it manually, 2. The user listens to a song completely.\n\nBecause the language used to build this software will be C#, this software will be used easily on any Windows operated machine. The database will be managed using MySQL, which is the most widely used open-source relational database management system.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Adhiraj Singh Chauhan")]
[assembly: AssemblyProduct("Music Manager")]
[assembly: AssemblyCopyright("Copyright © Adhiraj Singh Chauhan 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("346a0fac-78f5-4cec-87c3-276ca8a7620e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.1.0.*")]
[assembly: AssemblyFileVersion("1.1.0.*")]
