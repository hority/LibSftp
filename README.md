# LibSftp
This is an experimental impl focused on SFTP using SSH.NET.

## Requirement
[sshnet/SSH.NET](https://github.com/sshnet/SSH.NET)

- Note: If you want to build for .net35, make sure your SSH.NET includes [this patch](https://github.com/sshnet/SSH.NET/commit/710aa37bd583ced661b02d008514c07c505e6f3d).

## Usage
```cs
var transferer = FileTransferer.Create("hostname", 22, "username", "password");
transferer.Download("/path/to/remote", "/path/to/local");
```
