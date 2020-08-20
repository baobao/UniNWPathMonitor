import Foundation
import UIKit
import Network

@available(iOS 12.0, *)

@objcMembers
public class UniNWPathMonitor : NSObject
{
  private let monitor = NWPathMonitor()
  private let queue = DispatchQueue(label: "info.shibuya24.UniNWPathMonitor")
  private var _onCallback: ((String) -> Void)!

  public func execute()
  {
    monitor.pathUpdateHandler = { path in
        if path.status == .satisfied {
            // connected
            self._onCallback("1")
        } else {
            // No connected
            self._onCallback("0")
        }
    }
    monitor.start(queue: queue)
  }

  public func setCallback(onCallback: ((String)->Void)!)
  {
    _onCallback = onCallback
  }
}
