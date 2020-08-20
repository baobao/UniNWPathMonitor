# UniNWPathMonitor
Network Status Checking component using NWPathMonitor.

## Required
- iOS12 or newer


## Usage 

```cs
UniNWPathMonitor.StartMonitor();
UniNWPathMonitor.onChangeNetworkStatus += status => {
    // Do Smoething..
};
```
