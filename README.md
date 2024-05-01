# NWN.ProcessEventInfiniteLoopRepro

Repro project for a bug in Anvil that throws `System.IndexOutOfRangeException` from `VirtualMachine.cs::ExecuteInScriptContext` _after_ having reloaded services that contain subscriptions to events that are also subscribed to from nss.

## Getting started

### Run

These are the steps to reproduce the bug:

1. Build and run

```shell
dotnet build -c Debug
./run-commands.sh # to start the interactive menu
```

2. Use option 5 to pack the module
1. Use option 1 to start the container
1. Use option 7 to tail the server logs
1. Log in and sell something to the merchant. This should work fine.
1. Trigger a reload of dotnet, e.g. by starting a watcher in a separate terminal and saving a file

```shell
dotnet watch --project NWN.ProcessEventInfiniteLoopRepro/Repro.csproj build -c Debug
```

7. Watch Anvil reload plugins.
1. Try to sell something again.
1. Observe the process crash.

### Use

Use [nasher](https://github.com/squattingmonk/nasher) to manage the sources.

A utility script named `./run-commands.sh` has been added to speed up running frequent commands, inlcuding a useful watch-utility to hot compile scripts on file save (option 2).

## Requirements

- `docker` (with `compose`)
- `nasher`
- `dotnet`
- `entr` (to hot compile nss)
