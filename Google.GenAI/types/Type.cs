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

using System.Text.Json.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// The type of the data.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum Type {
    /// <summary>
    /// Not specified, should not be used.
    /// </summary>
    [JsonPropertyName("TYPE_UNSPECIFIED")] TYPE_UNSPECIFIED,

    /// <summary>
    /// OpenAPI string type
    /// </summary>
    [JsonPropertyName("STRING")] STRING,

    /// <summary>
    /// OpenAPI number type
    /// </summary>
    [JsonPropertyName("NUMBER")] NUMBER,

    /// <summary>
    /// OpenAPI integer type
    /// </summary>
    [JsonPropertyName("INTEGER")] INTEGER,

    /// <summary>
    /// OpenAPI boolean type
    /// </summary>
    [JsonPropertyName("BOOLEAN")] BOOLEAN,

    /// <summary>
    /// OpenAPI array type
    /// </summary>
    [JsonPropertyName("ARRAY")] ARRAY,

    /// <summary>
    /// OpenAPI object type
    /// </summary>
    [JsonPropertyName("OBJECT")] OBJECT,

    /// <summary>
    /// Null type
    /// </summary>
    [JsonPropertyName("NULL")] NULL
  }
}
