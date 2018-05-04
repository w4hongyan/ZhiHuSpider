/*
 * Copyright (c) 2015-present, Parse, LLC.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */
package com.parse;

/** package */ enum PushType {
  NONE ("none"),
  PPNS ("ppns"),
  GCM ("gcm");

  private final String pushType;

  /* package */ PushType(String pushType) {
    this.pushType = pushType;
  }

  /* package */ static PushType fromString(String pushType) {
    if ("none".equals(pushType)) {
      return PushType.NONE;
    } else if ("ppns".equals(pushType)) {
      return PushType.PPNS;
    } else if ("gcm".equals(pushType)) {
      return PushType.GCM;
    } else {
      return null;
    }
  }

  @Override
  public String toString() {
    return pushType;
  }
}
