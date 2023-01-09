# winlnk
windows shortcut file(.lnk) utility


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
