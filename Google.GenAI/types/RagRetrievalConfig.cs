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
  /// Specifies the context retrieval config. This data type is not supported in Gemini API.
  /// </summary>

  public record RagRetrievalConfig {
    /// <summary>
    /// Optional. Config for filters.
    /// </summary>
    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagRetrievalConfigFilter ? Filter { get; set; }

    /// <summary>
    /// Optional. Config for Hybrid Search.
    /// </summary>
    [JsonPropertyName("hybridSearch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagRetrievalConfigHybridSearch
        ? HybridSearch {
            get; set;
          }

    /// <summary>
    /// Optional. Config for ranking and reranking.
    /// </summary>
    [JsonPropertyName("ranking")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagRetrievalConfigRanking
        ? Ranking {
            get; set;
          }

    /// <summary>
    /// Optional. The number of contexts to retrieve.
    /// </summary>
    [JsonPropertyName("topK")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TopK {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a RagRetrievalConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RagRetrievalConfig object, or null if deserialization
    /// fails.</returns>
    public static RagRetrievalConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<RagRetrievalConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
