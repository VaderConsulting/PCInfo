# PCInfo

PCInfo is a Visual Studio VB.NET Windows service (`PCInfo Service`) that periodically reads config and uses WMI `Win32_Process` plus TCP send/receive helpers. Companion projects TCPSend and TCPReceive wrap Rijndael over a localhost TCP stream (demo key/IV). A Test WinForms project exercises process/logon helpers. It is my working copy from Historical Dev.

**Source last updated:** 2005-07-29  
**Language:** VB.NET  
**Target:** .NET Windows service  
**Output:** Service + TCP helpers + Test exe

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `PCInfoService` | VB.NET | Windows service | Timer-driven PCInfo service |
| `TCPSend` | VB.NET | Helper | Encrypt and send on TCP |
| `TCPReceive` | VB.NET | Helper | Receive and decrypt |
| `Test` | VB.NET | WinForms | WMI process / logon tests |

## How to open

Open `PCInfoService/PCInfoService.sln` in Visual Studio.

## Requirements

- Visual Studio .NET 2003
- .NET Framework 1.1

## Attribution and provenance

From Dave Robinson's Historical Dev archive (OneDrive folder `PCInfo`). TCP samples use a documented localhost demo key, not production credentials.

## License

MIT License. Copyright (c) 2026 Vader Consulting.
