using System;
using UnityEngine;

namespace ShusmoAPI
{
        public static class Link
        {
            public static Action<string> OnActivation;
            private static string id = string.Empty;

            /// <summary>
            /// The tool ID provided on Initialize.
            /// </summary>
            public static string ID => id;

            /// <summary>
            /// Initialize the tool.
            /// </summary>
            /// <param name="gameName">The ID will be used on the tool</param>
            public static void Init(string gameName)
            {
                id = gameName;
                Application.deepLinkActivated += HandleDeepLinkActivation;
                OnActivation?.Invoke("DeeoLink_Init");
            }

            private static void HandleDeepLinkActivation(string url)
            {
                // Check if the game was launched from a deep link
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        string message = url.Split("message=")[1];
                        OnActivation?.Invoke(message);
                    }
                    catch { }
                }
            }

            /// <summary>
            /// Generate a URL text from a message.
            /// </summary>
            /// <param name="message">The desired message</param>
            /// <returns>URL with the message</returns>
            public static String GenerateMessage(string message) => $"https://shusmo.io/{id}?message={message}";

            /// <summary>
            /// Activate the tool with a URL.
            /// </summary>
            /// <param name="url">URL for read the message from it</param>
            public static void Activate(string url) => HandleDeepLinkActivation(url);
        }
    }