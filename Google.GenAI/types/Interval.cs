/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// Auto-generated code. Do not edit.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Represents a time interval, encoded as a Timestamp start (inclusive) and a Timestamp end
  /// (exclusive). The start must be less than or equal to the end. When the start equals the end,
  /// the interval is empty (matches no time). When both start and end are unspecified, the interval
  /// matches any time.
  /// </summary>

  public record Interval {
    /// <summary>
    /// Optional. Exclusive end of the interval. If specified, a Timestamp matching this interval
    /// will have to be before the end.
    /// </summary>
    [JsonPropertyName("endTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime ? EndTime { get; set; }

    /// <summary>
    /// Optional. Inclusive start of the interval. If specified, a Timestamp matching this interval
    /// will have to be the same or after the start.
    /// </summary>
    [JsonPropertyName("startTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? StartTime {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Interval object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Interval object, or null if deserialization fails.</returns>
    public static Interval ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Interval>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
