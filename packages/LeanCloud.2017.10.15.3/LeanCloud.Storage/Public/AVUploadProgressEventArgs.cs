// Copyright (c) 2015-present, Parse, LLC.  All rights reserved.  This source code is licensed under the BSD-style license found in the LICENSE file in the root directory of this source tree.  An additional grant of patent rights can be found in the PATENTS file in the same directory.

using System;

namespace LeanCloud {
  /// <summary>
  /// Represents upload progress.
  /// </summary>
  public class AVUploadProgressEventArgs : EventArgs {
    public AVUploadProgressEventArgs() { }

    /// <summary>
    /// Gets the progress (a number between 0.0 and 1.0) of an upload.
    /// </summary>
    public double Progress { get; set; }
  }
}
