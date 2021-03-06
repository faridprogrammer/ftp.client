# ftp.client

A simple ftp client written in C# for test purposes

Using it is straightforward. You need to run an exe file with different parameters. 

Currently these ftp commands are available in the tool.

- `upload-file` (Fetch folder content list)
- `fetch-folder` (Upload file from local path to a remote path)
- `download-folder` (Dowloads a remote folder contents to a **RANDOM** local folder path)
- `connect` (Connects to a ftp server)
- `disconnect` (Disconnects application from ftp server)
- `exit` (Exit application)


## `connect` parameters

  -h, --Host           Required.

  -u, --username       Required.

  -s, --password

  -l, --ssl            Enable ssl support

  -v, --passive        Set true to enable passive mode

  -a, --active_ports   Active ports

  -e, --external-ip    Set this parameter to your NAT outgoing IP if you are operating within a NAT

  -r, --certificate    Certificate string. If this parameter has been set then the validation will occur.
  
  -d, --debug          Enables detailed logging.

  --help               Display this help screen.

  --version            Display version information.
  
## `disconnect` parameters

  --help               Display this help screen.

  --version            Display version information.


## `upload-file` parameters

  -p, --path           Remote path. Required.

  -f, --local-path     Required. Local path of the file to upload

  --help               Display this help screen.

  --version            Display version information.

## `fetch-folder` parameters
  
  -p, --path           Remote path. Required.

  --help               Display this help screen.

  --version            Display version information.

## `download-folder` parameters
  
  -p, --path           Remote path. Required.

  --help               Display this help screen.

  --version            Display version information.
  
## `exit` parameters
  
  --help               Display this help screen.

  --version            Display version information.

## Basic usage

In order to call simple ftp commands within this application (using dotnet) to test ftp connection or something like this, you can use the following command structure. 


    # PowerShell
    ./Ftp.Client.exe
    $ connect -h 127.0.0.1 -u test -p is.not.required
    $ fetch_folder -p path.of.folder.to.get.listing`
    $ disconnect
    $ exit



## Download

You can download the latest version [here](https://github.com/faridprogrammer/ftp.client/releases/tag/v2.0.0).





