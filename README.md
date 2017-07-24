# LibSftp
experimental impl by SSH.NET

## Built With
[SSH.NET](https://github.com/sshnet/SSH.NET)

## Usage
```cs
var transferer = FileTransferer.Create("hostname", 22, "username", "password");
transferer.Download("/path/to/remote", "/path/to/local");
```
