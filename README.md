# winlnk

windows shortcut file(.lnk) utility

## What is winlnk

winlnk is a parser of Windows Shortcut file.

## What is Windows Shortcut file.

Windows Shortcut file is shell link file in Windows OS.

## What is Windows Shortcut file format.

See [Official Document @Microsoft](https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-shllink/16cb4ca1-9339-4d0c-a68d-bf1d6cc0f943)

# how to use

1. git clone
1. dotnet build
1. winlnk sample.lnk

```shell
$ winlnk sample.lnk
{
  "ShellLinkHeader": {
    "HeaderSize": 76,
    "LinkCLSID": "00021401-0000-0000-c000-000000000046",
    "LinkFlags": {
      "HasLinkTargetIDList": true,
...
```

winlnk --load sample.json -o sample.lnk

# More Documents.

https://maetaro.github.io/winlnk/docs/

# TEST Results Report.

https://maetaro.github.io/winlnk/testResults/

# TEST Coverage Report.

https://maetaro.github.io/winlnk/cov/

