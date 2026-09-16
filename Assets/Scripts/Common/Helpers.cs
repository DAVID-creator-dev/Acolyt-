using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Helpers
{
    private static readonly System.Random rng = new System.Random();

    public static string GetDownloadsPath()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        return path;
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static byte[] SpriteToPng(Sprite sprite)
    {
        Rect rect = sprite.textureRect;
        Texture2D source = sprite.texture;

        Texture2D cropped = new Texture2D((int)rect.width, (int)rect.height);
        cropped.SetPixels(source.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
        cropped.Apply();

        return cropped.EncodeToPNG();
    }
}
