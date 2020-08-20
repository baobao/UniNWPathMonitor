#import <UnityFramework/UnityFramework-Swift.h>

extern "C"
{
    API_AVAILABLE(ios(12.0))
    UniNWPathMonitor *_monitor;

    void StartMonitor__()
    {
        if (@available(iOS 12.0, *))
        {
            if (_monitor == nullptr)
            {
                _monitor = [[UniNWPathMonitor alloc] init];
                [_monitor execute];
                // swift側を変更した際は、⌘+bでビルドする
                [_monitor setCallbackOnCallback:^(NSString * value) {
                    UnitySendMessage("UniNWPathMonitor", "Noti", [value UTF8String]);
                }];
            }
        } else {
            // Fallback on earlier versions
        }
    }
}
