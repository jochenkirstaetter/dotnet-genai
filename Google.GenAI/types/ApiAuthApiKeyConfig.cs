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
  /// The API secret. This data type is not supported in Gemini API.
  /// </summary>

  public record ApiAuthApiKeyConfig {
    /// <summary>
    /// The SecretManager secret version resource name storing API key. e.g.
    /// projects/{project}/secrets/{secret}/versions/{version}
    /// </summary>
    [JsonPropertyName("apiKeySecretVersion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? ApiKeySecretVersion { get; set; }

    /// <summary>
    /// The API key string. Either this or `api_key_secret_version` must be set.
    /// </summary>
    [JsonPropertyName("apiKeyString")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ApiKeyString {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ApiAuthApiKeyConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ApiAuthApiKeyConfig object, or null if deserialization
    /// fails.</returns>
    public static ApiAuthApiKeyConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ApiAuthApiKeyConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
