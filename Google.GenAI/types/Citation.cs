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
  /// Source attributions for content. This data type is not supported in Gemini API.
  /// </summary>

  public record Citation {
    /// <summary>
    /// Output only. End index into the content.
    /// </summary>
    [JsonPropertyName("endIndex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? EndIndex { get; set; }

    /// <summary>
    /// Output only. License of the attribution.
    /// </summary>
    [JsonPropertyName("license")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? License {
            get; set;
          }

    /// <summary>
    /// Output only. Publication date of the attribution.
    /// </summary>
    [JsonPropertyName("publicationDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleTypeDate
        ? PublicationDate {
            get; set;
          }

    /// <summary>
    /// Output only. Start index into the content.
    /// </summary>
    [JsonPropertyName("startIndex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? StartIndex {
            get; set;
          }

    /// <summary>
    /// Output only. Title of the attribution.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// Output only. Url reference of the attribution.
    /// </summary>
    [JsonPropertyName("uri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Uri {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Citation object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Citation object, or null if deserialization fails.</returns>
    public static Citation ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Citation>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
