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
  /// Represents where the chunk starts and ends in the document. This data type is not supported in
  /// Gemini API.
  /// </summary>

  public record RagChunkPageSpan {
    /// <summary>
    /// Page where chunk starts in the document. Inclusive. 1-indexed.
    /// </summary>
    [JsonPropertyName("firstPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? FirstPage { get; set; }

    /// <summary>
    /// Page where chunk ends in the document. Inclusive. 1-indexed.
    /// </summary>
    [JsonPropertyName("lastPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? LastPage {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a RagChunkPageSpan object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RagChunkPageSpan object, or null if deserialization
    /// fails.</returns>
    public static RagChunkPageSpan
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<RagChunkPageSpan>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
