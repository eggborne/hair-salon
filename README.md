# Eau Claire's Salon
#### Special Project #9 for Epicodus, 10 March 2023
### by Mike Donovan

## Description

A C#/ASP.NET/EFCore web app that allows a user to view and edit a database of hair stylists and associated clients.

## Technologies Used:
* C#
* .NET
* ASP.NET
* Entity Framework Core

## Setup/Installation Instructions

1. Clone this repo.
2. In the repo folder, navigate to `HairSalon/` and open `appsettings.json.example`.
3. Replace `[YOUR-DB-NAME]`, `[YOUR-USER-HERE]`, and `[YOUR-PASSWORD-HERE]` with your own credentials.
4. Save the file as `appsettings.json`.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory called "VendorTracker". 
3. Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
4. Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. For more information, [visit the Microsoft documentation on dev-certs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs).

## Known Bugs

* On the "Edit Client" screen, the "Back to List" button always goes back to the full client list even if the user got there from a link in a partial list on a "Stylist Details" page.

## Legal

MIT License

Copyright (c) 2023 Mike Donovan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
