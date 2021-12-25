# ftp.client
A very simple ftp client written in C# for test purposes

Using it is very straightforward. You need to run an exe file with different parameters. 

Currently there is two ftp commands available in the tool.

- `upload-file` (Fetch folder content list)
- `fetch-folder` (Upload file from local path to a remote path)

## `upload-file` parameters

  -p, --path           Required.

  -f, --local-path     Required. Local path of the file to upload

  -h, --Host           Required.

  -u, --username       Required.

  -s, --password

  -l, --ssl            Enable ssl support

  -v, --passive        Set true to enable passive mode

  -e, --external-ip    Set this parameter to your NAT outgoing IP if you are operating within a NAT

  --help               Display this help screen.

  --version            Display version information.

## `fetch-folder` parameters
  
  -p, --path           Required.

  -h, --Host           Required.

  -u, --username       Required.

  -s, --password

  -l, --ssl            Enable ssl support

  -v, --passive        Set true to enable passive mode

  -e, --external-ip    Set this parameter to your NAT outgoing IP if you are
                       operating within a NAT

  --help               Display this help screen.

  --version            Display version information.


## Basic usage

In order to call simple ftp commands within this application (using dotnet) to test ftp connection or something like this, you can use the following command structure. 

`FtpChecker.exe fetch_folder -p path.of.folder.to.get.listing -h 127.0.0.1 -u test -p is.not.required`

## Download

You can download the latest version [here](https://github.com/faridprogrammer/ftp.client/releases/tag/V1.0).





