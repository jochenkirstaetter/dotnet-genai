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
  /// When manual routing is set, the specified model will be used directly. This data type is not
  /// supported in Gemini API.
  /// </summary>

  public record GenerationConfigRoutingConfigManualRoutingMode {
    /// <summary>
    /// The model name to use. Only the public LLM models are accepted. See Supported models
    /// (https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference#supported-models).
    /// </summary>
    [JsonPropertyName("modelName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? ModelName { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a GenerationConfigRoutingConfigManualRoutingMode object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerationConfigRoutingConfigManualRoutingMode object, or null if
    /// deserialization fails.</returns>
    public static GenerationConfigRoutingConfigManualRoutingMode
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerationConfigRoutingConfigManualRoutingMode>(
            jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
