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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class RecontextImageTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string productRecontextModel;
  private string virtualTryOnModel;
  public TestContext TestContext { get; set; }

  [ClassInitialize]
  public static void ClassInit(TestContext _) {
    _server = TestServer.StartTestServer();
  }

  [ClassCleanup]
  public static void ClassCleanup() {
    TestServer.StopTestServer(_server);
  }

  [TestInitialize]
  public void TestInit() {
    // Test server specific setup.
    if (_server == null) {
      throw new InvalidOperationException("Test server is not initialized.");
    }
    var geminiClientHttpOptions = new HttpOptions { Headers = new Dictionary<string, string> {
      { "Test-Name", $"{GetType().Name}.{TestContext.TestName}" }
    } };
    var vertexClientHttpOptions = new HttpOptions { Headers = new Dictionary<string, string> {
      { "Test-Name", $"{GetType().Name}.{TestContext.TestName}" }
    } };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    Client.setDefaultBaseUrl(vertexBaseUrl: "http://localhost:1454",
                             geminiBaseUrl: "http://localhost:1453");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    productRecontextModel = "imagen-product-recontext-preview-06-30";
    virtualTryOnModel = "virtual-try-on-preview-08-04";
  }

  [TestMethod]
  public async Task RecontextImageGeminiTest() {
    List<ProductImage> productImages = new List<ProductImage>();

    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.RecontextImageAsync(
        model: productRecontextModel,
        source: new RecontextImageSource {
          Prompt = "On a school desk",
          ProductImages = productImages,
        },
        config: null);
    });

    StringAssert.Contains(ex.Message, "only supported in the Vertex AI client");
  }

  [TestMethod]
  public async Task RecontextImageVertexTest() {
    List<ProductImage> productImages = new List<ProductImage>();

    productImages.Add(new ProductImage {
      ProductImageField = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/backpack1.png"
      }
    });
    var recontextImageConfig = new RecontextImageConfig {
      NumberOfImages = 1,
      AddWatermark = true,
      OutputMimeType = "image/jpeg",
      Labels = new Dictionary<string, string> { ["imagen_label_key"] = "recontext_image" },
    };

    var recontextImageResponse = await vertexClient.Models.RecontextImageAsync(
        model: productRecontextModel,
        source: new RecontextImageSource {
          Prompt = "On a school desk",
          ProductImages = productImages,
        },
        config: recontextImageConfig);

    Assert.IsNotNull(recontextImageResponse.GeneratedImages);
    Assert.AreEqual(recontextImageResponse.GeneratedImages.Count, 1, "Expected 1 generated image.");
    Assert.IsNotNull(recontextImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task RecontextImageAllConfigVertexTest() {
    List<ProductImage> productImages = new List<ProductImage>();

    productImages.Add(new ProductImage {
      ProductImageField = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/backpack1.png"
      }
    });
    productImages.Add(new ProductImage {
      ProductImageField = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/backpack2.png"
      }
    });
    productImages.Add(new ProductImage {
      ProductImageField = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/backpack3.png"
      }
    });
    var recontextImageConfig = new RecontextImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
      BaseSteps = 32,
      Seed = 1337,
      AddWatermark = false,
      SafetyFilterLevel = SafetyFilterLevel.BLOCK_MEDIUM_AND_ABOVE,
      PersonGeneration = PersonGeneration.ALLOW_ADULT,
      OutputCompressionQuality = 75,
      EnhancePrompt = false,
      Labels = new Dictionary<string, string> { ["imagen_label_key"] = "recontext_image" },
    };

    var recontextImageResponse = await vertexClient.Models.RecontextImageAsync(
        model: productRecontextModel,
        source: new RecontextImageSource {
          Prompt = "On a school desk",
          ProductImages = productImages,
        },
        config: recontextImageConfig);

    Assert.IsNotNull(recontextImageResponse.GeneratedImages);
    Assert.AreEqual(recontextImageResponse.GeneratedImages.Count, 1, "Expected 1 generated image.");
    Assert.IsNotNull(recontextImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task VirtualTryOnVertexTest() {
    List<ProductImage> productImages = new List<ProductImage>();

    productImages.Add(new ProductImage {
      ProductImageField = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/pants.jpg"
      }
    });
    var recontextImageConfig = new RecontextImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
      Labels = new Dictionary<string, string> { ["imagen_label_key"] = "recontext_image" },
    };

    var recontextImageResponse = await vertexClient.Models.RecontextImageAsync(
        model: virtualTryOnModel,
        source: new RecontextImageSource {
          PersonImage = new Image {
            GcsUri = "gs://genai-sdk-tests/inputs/images/man.jpg"
          },
          ProductImages = productImages,
        },
        config: recontextImageConfig);

    Assert.IsNotNull(recontextImageResponse.GeneratedImages);
    Assert.AreEqual(recontextImageResponse.GeneratedImages.Count, 1, "Expected 1 generated image.");
    Assert.IsNotNull(recontextImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task VirtualTryOnAllConfigVertexTest() {
    List<ProductImage> productImages = new List<ProductImage>();

    productImages.Add(new ProductImage {
      ProductImageField = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/pants.jpg"
      }
    });
    var recontextImageConfig = new RecontextImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
      BaseSteps = 32,
      Seed = 1337,
      AddWatermark = false,
      SafetyFilterLevel = SafetyFilterLevel.BLOCK_MEDIUM_AND_ABOVE,
      PersonGeneration = PersonGeneration.ALLOW_ADULT,
      OutputCompressionQuality = 75,
      EnhancePrompt = false,
      Labels = new Dictionary<string, string> { ["imagen_label_key"] = "recontext_image" },
    };

    var recontextImageResponse = await vertexClient.Models.RecontextImageAsync(
        model: virtualTryOnModel,
        source: new RecontextImageSource {
          PersonImage = new Image {
            GcsUri = "gs://genai-sdk-tests/inputs/images/man.jpg"
          },
          ProductImages = productImages,
        },
        config: recontextImageConfig);

    Assert.IsNotNull(recontextImageResponse.GeneratedImages);
    Assert.AreEqual(recontextImageResponse.GeneratedImages.Count, 1, "Expected 1 generated image.");
    Assert.IsNotNull(recontextImageResponse.GeneratedImages.First().Image.ImageBytes);
  }
}
