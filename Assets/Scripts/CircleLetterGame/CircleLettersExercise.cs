using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class CircleLettersExercise : MonoBehaviour
{
    [SerializeField] private CircleLettersManager circleLettersManager;

    void Start()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void GeneratePdf()
    {
        List<WordDataScriptable> words = GameManager.Instance.GetExerciseWords().ToList();
        string letters = circleLettersManager.GetExerciseLetters();
        words.Shuffle();

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(16));

                page.Content().Column(column =>
                {
                    column.Item().Row(row =>
                    {
                        row.RelativeItem().AlignLeft().Text("Prénom : .................");
                        row.RelativeItem().AlignRight().Text("Date : .................");
                    });

                    column.Item().PaddingBottom(20);

                    column.Item().Border(1).Padding(5).AlignCenter().Text($"Entoure les lettres ({string.Join(",", letters.ToCharArray())}).").FontSize(14);
                    column.Item().PaddingBottom(15);

                    column.Item().PaddingBottom(20);

                    const int maxWordsPerColumn = 6;
                    bool splitColumns = words.Count > maxWordsPerColumn;
                    int splitIndex = splitColumns ? (words.Count + 1) / 2 : words.Count;

                    List<WordDataScriptable> leftWords = words.Take(splitIndex).ToList();
                    List<WordDataScriptable> rightWords = words.Skip(splitIndex).ToList();

                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Column(leftColumn =>
                        {
                            foreach (WordDataScriptable word in leftWords)
                                leftColumn.Item().PaddingVertical(10).Text(word.word.ToLower()).FontSize(28);
                        });

                        if (splitColumns)
                            row.RelativeItem().Column(rightColumn =>
                            {
                                foreach (WordDataScriptable word in rightWords)
                                    rightColumn.Item().PaddingVertical(10).Text(word.word.ToLower()).FontSize(28);
                            });
                    });
                });
            });
        })
        .GeneratePdf(Path.Combine(Helpers.GetDownloadsPath(), "circle_letters_exercise.pdf"));
    }
}
